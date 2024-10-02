using Katuusagi.ConstExpressionForUnity.Editor;
using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public abstract class GetMemberErrorHandlerBase<T> : IErrorHandler
        where T : MemberReference
    {
        public string Name { get; set; }
        public abstract string MemberType { get; }

        public abstract IEnumerable<T> GetMembers(TypeDefinition type);

        public abstract void Check(MethodDefinition method, Instruction instruction, MethodReference called, IReadOnlyList<Instruction> argInstructions, IReadOnlyDictionary<string, object> parameters);

        protected IEnumerable<T> GetMembers(TypeDefinition typeDef, string name, BindingFlags bindingFlags, bool withBase)
        {
            var members = GetMembers(typeDef).ToList();
            if ((bindingFlags & BindingFlags.DeclaredOnly) != 0)
            {
                GetBasePublicMembers(typeDef, members);
            }

            var result = members.Where(v =>
            {
                var memberName = v.Name;
                if (name != null)
                {
                    if ((bindingFlags & BindingFlags.IgnoreCase) == 0)
                    {
                        if (memberName != name)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!memberName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                }

                if (v.IsPublic())
                {
                    if ((bindingFlags & BindingFlags.Public) == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if ((bindingFlags & BindingFlags.NonPublic) == 0)
                    {
                        return false;
                    }
                }

                if (v is TypeReference)
                {
                    return true;
                }

                if (v.IsStatic())
                {
                    if ((bindingFlags & BindingFlags.Static) == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if ((bindingFlags & BindingFlags.Instance) == 0)
                    {
                        return false;
                    }
                }

                return true;
            });

            if (withBase && typeDef.BaseType != null)
            {
                var baseDef = typeDef.BaseType.Resolve();
                var baseMembers = GetMembers(baseDef, name, bindingFlags, withBase);
                result = result.Concat(baseMembers);
            }

            return result;
        }

        protected void GetBasePublicMembers(TypeDefinition type, List<T> result)
        {
            if (type.BaseType == null)
            {
                return;
            }

            var baseType = type.BaseType.Resolve();
            var members = GetMembers(baseType);
            result.AddRange(members);
            GetBasePublicMembers(baseType, result);
        }

        protected static void GetMemberParameters(IReadOnlyDictionary<string, object> param, MethodReference called, out TypeReference type, out string name, out BindingFlags bindingFlags)
        {
            TryGetParameter(param, "name", out name);
            GetMemberParameters(param, called, out type, out bindingFlags);
        }

        protected static void GetMemberParameters(IReadOnlyDictionary<string, object> param, MethodReference called, out TypeReference type, out BindingFlags bindingFlags)
        {
            if (!TryGetParameter(param, "type", out type))
            {
                type = called.GetGenericArguments().First();
            }

            if (TryGetParameter(param, "bindingFlags", out bindingFlags))
            {
                return;
            }

            bindingFlags = BindingFlags.Public;
            if (called.Name.Contains("FullAccess"))
            {
                bindingFlags |= BindingFlags.NonPublic;
            }

            if (called.Name.Contains("Instance"))
            {
                bindingFlags |= BindingFlags.Instance;
            }
            else if (called.Name.Contains("Static"))
            {
                bindingFlags |= BindingFlags.Static;
            }
            else
            {
                bindingFlags |= BindingFlags.Instance | BindingFlags.Static;
            }
        }

        protected static bool TryGetParameter<TValue>(IReadOnlyDictionary<string, object> parameterTable, string name, out TValue value)
        {
            if (!parameterTable.TryGetValue(name, out var tmp))
            {
                value = default;
                return false;
            }

            if (tmp == null && !typeof(TValue).IsValueType)
            {
                value = default;
                return true;
            }

            if (tmp is TValue v)
            {
                value = v;
                return true;
            }

            if (typeof(TValue).IsEnum)
            {
                value = (TValue)Enum.ToObject(typeof(TValue), tmp);
                return true;
            }

            value = default;
            return false;
        }
    }
}
