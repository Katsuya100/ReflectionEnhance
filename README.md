# ReflectionEnhance
[日本語](README_ja.md)

## Overview
The "ReflectionEnhance" library provides high-speed reflection capabilities.  
It can execute faster than the standard .NET `System.Reflection`.

## Verified Operating Environments
|  Environment  |  Version  |
| ---- | ---- |
| Unity | 2021.3.38f1, 2022.3.20f1 |
| .Net | 4.x, Standard 2.1 |

## Performance
### Measurement Code in the Editor
[Assembly Test Code](packages/Tests/Runtime/REAssembly/AssemblyPerformanceTest.cs)  
[Type Test Code](packages/Tests/Runtime/REType/TypePerformanceTest.cs)  
[ConstructorInfo Test Code](packages/Tests/Runtime/REConstructorInfo/ConstructorInfoPerformanceTest.cs)  
[FieldInfo Test Code](packages/Tests/Runtime/REFieldInfo/FieldInfoPerformanceTest.cs)  
[MethodBase Test Code](packages/Tests/Runtime/REMethodBase/MethodBasePerformanceTest.cs)  
[Enum Test Code](packages/Tests/Runtime/REEnum/EnumPerformanceTest.cs) 

Note: The same measurement code is used after building as well.

#### Results
Below is an excerpt:

|  Method  |  Mono(Develop)  |  Mono(Release)  |  IL2CPP(Develop)  |  IL2CPP(Release)  |
| ---- | ---- | ---- | ---- | ---- |
| Type.GetField(Legacy) | 3.80069 sec | 3.789642 sec | 6.671875 sec | 6.617188 sec | 
| Type.GetFieldFast | 0.009490967 sec | 0.009613037 sec | 0.0078125 sec | 0.0078125 sec | 
| Type.FieldOf | 0.5515747 sec | 0.5567932 sec | 0.171875 sec | 0.1640625 sec |
| FieldInfo.GetValue(Legacy) | 1.1716 sec | 1.239502 sec | 0.6152344 sec | 0.5097656 sec | 
| FieldInfo.GetStaticValueFast | 0.2137909 sec | 0.2355499 sec | 0.3222656 sec | 0.2871094 sec | 
| StaticFieldPointer.GetValue | 0.01437378 sec | 0.01635742 sec | 0.015625 sec | 0.01171875 sec | 
| MethodBase.Invoke(Legacy) | 3.869812 sec | 4.164734 sec | 1.865234 sec | 1.8125 sec | 
| MethodBase.InvokeStaticFast | 0.240387 sec | 0.2815857 sec | 0.296875 sec | 0.3085938 sec | 
| StaticMethodPointerFunc.Invoke | 0.04116821 sec | 0.05160522 sec | 0.04296875 sec | 0.03125 sec | 
| Delegate | 0.0333252 sec | 0.04013062 sec | 0.03125 sec | 0.0234375 sec | 

[Detailed Measurement Results](measure.csv)  

`GetField` can virtually eliminate processing time under certain conditions.  
The same applies to other `GetMember` methods.  
Using `FieldOf` also speeds up processing, though not as much as `GetFieldFast`.  
(Additionally, since it doesn't create a cache, it's memory-efficient.)  
`GetValue` shows about a 5x performance improvement, and Invoke about 16x.  
Moreover, converting the `FieldInfo` type to a `FieldPointer` type results in an 81x improvement.  
Converting the `MethodBase` type to a `MethodPointer` type results in about a 94x performance increase.  
(While the `Delegate` type is even faster, using the `MethodPointer` type for instance methods has the advantage of being able to change the target.)  

## Installation Instructions
### Install Dependent Packages
Install the following packages:  

- [BoxingPool v1.3.1](https://github.com/Katsuya100/BoxingPool/tree/ver1.3.1)
- [ILPpostProcessorCommon v2.3.0](https://github.com/Katsuya100/ILPostProcessorCommon/tree/ver2.3.0)
- [MemoizationForUnity v1.5.0](https://github.com/Katsuya100/MemoizationForUnity/tree/ver1.5.0)
- [GenericEnhance v1.1.0](https://github.com/Katsuya100/GenericEnhance/tree/ver1.1.0)
- [ConstExpressionForUnity v3.2.0](https://github.com/Katsuya100/ConstExpressionForUnity/tree/ver3.2.0)

### Install ReflectionEnhance
1. Open [Window > Package Manager].
2. Click [+ > Add package from git URL...].
3. Enter https://github.com/Katsuya100/ReflectionEnhance.git?path=packages and click [Add].

#### If It Doesn't Work
The above method may not work in environments where Git is not installed.  
Please download the com.katuusagi.arraypool.tgz of the corresponding version from Releases and install it using [Package Manager > + > Add package from tarball...].

#### If It Still Doesn't Work
Download the Katuusagi.ReflectionEnhance.unitypackage of the corresponding version from [Releases](https://github.com/Katsuya100/ReflectionEnhance/releases) and import it into the project via [Assets > Import Package > Custom Package].

## Usage
### Compatible Methods
Many members with the `Fast` suffix are provided as compatible methods, as shown below:  
```.cs
//  field = typeof(Vector3).GetField("x");
var field = typeof(Vector3).GetFieldFast("x");
```

Compatible methods with additional conditions are also provided:  
```.cs
//  x = field.GetValue(vec);
var x = field.GetInstanceValueFast<Vector3, float>(ref vec);
```
Especially, methods like `GetValue` and `Invoke` can specify types via generic arguments for optimization.  

### FieldPointer/MethodPointer Types
You can implicitly convert from a `FieldInfo` type to a `FieldPointer` as follows:  
```.cs
InstanceFieldPointer<Vector3, float> field = typeof(Vector3).GetFieldFast("x");
var x = field.GetValue(ref vec);
```

The FieldPointer type allows even faster access than the compatible methods of FieldInfo.  
A MethodPointer type is also provided.  
Unlike a delegate, you can specify the target when invoking:  
```.cs
InstanceMethodPointerAction<Vector3, float, float, float> method = typeof(Vector3).GetMethodFast<float, float, float>("Set")
method.Invoke(ref vec, 1, 2, 3);
```

### Substitution Types
`Substitution` types are provided so that you can specify ByRef types in generic arguments like in `GetMethodFast`.
You can specify ByRef types in generic arguments using the notation below:
```.cs
var method = typeof(Dictionary<string, int>).GetMethodFast<string, ByRefLike<int>>("TryGetValue");
int result = 0;
method.InstanceInvoke<string, ByRefLike<int>, bool>("hoge", ByRefLike.As(result));
```

Supported `Substitution` types are as follows:

|  Type Name  |  Meaning  |
| ---- | ---- |
|  ByRefLike\<T\> | ref T |
|  PointerLike\<T\> | T\* |
|  VoidLike | void |
|  GenericTypeParameterLike\<_N\> | N-th generic type parameter |
|  GenericMethodParameterLike\<_N\> | N-th generic method type parameter |

### FieldOf/MethodOf
Operators that can retrieve members at high speed are provided.  
Although they look like methods, internally they behave very similarly to typeof:  
```.cs
var field = typeof(Vector3).FieldOf("x");
var method = typeof(Vector3).MethodOf<float, float, float, VoidLike>("Set");
```
Specifying a non-existent member will result in a compile-time error.  
Also, since it retrieves directly from the handle, it's memory-efficient.   

### Convenient Methods
I provide many convenient methods that do not exist in the original reflection API.  
Here are some examples:  

|  Type  |  Method  |  Meaning  |
| ---- | ---- | ---- |
| REReflection | GetUsingGenericInstanceTypes | Retrieves a list of used GenericInstance types |
| REReflection | GetUsingArrayTypes | Retrieves a list of used array types |
| REReflection | GetUsingByRefTypes | Retrieves a list of used ByRef types |
| REReflection | GetUsingPointerTypes | Retrieves a list of used pointer types |
| REAssembly | IsReferenceTo | Determines if it references an assembly |
| REAssembly | IsReferenceFromo | Determines if it is referenced by an assembly |
| Type | GetTypeWithMoved |	Retrieves a type considering MovedFrom |
| Type | GetSerializeFields | Retrieves a list of SerializeFields |
| Type | IsArrayOfUnitySerialize | Determines if it is a type recognized as an array during Unity serialization |
| FieldInfo | IsSerializeField | Determines if it is a SerializeField |
| MethodBase | IsOverridable | Determines if it is a virtual method |
| MethodInfo | IsOperator | Determines if it is an operator overload method |
| MethodInfo | IsCompatible | Determines the compatibility of methods |

### Tips
#### Techniques for Speeding Up
It operates faster if all arguments are constants:
```.cs
// Slow implementation
t.GetFieldFast(memberName);

// Fast implementation
typeof(Vector3).GetFieldFast("x");
```

Also, it's faster not to cache typeof locally:
```.cs
// Slow implementation
var t = typeof(Vector3);
t.GetFieldFast(memberName);

// Fast implementation
typeof(Vector3).GetFieldFast(memberName);
```

#### Error Checking
`GetMember` methods perform compile-time existence checks when all arguments are constants:
```.cs
// This will result in a compile-time error.
typeof(Vector3).GetFieldFast("w");
```

## Reasons for High Speed
`ReflectionEnhance` optimizes `GetMember` methods through three stages: `StaticExpression`, `Compile-time Optimization`, and `Memoization`.  
First, when all arguments can be resolved at compile time as shown below, they are replaced during compilation through `StaticExpression` optimization:  
```.cs
var field = typeof(Vector3).GetFieldFast("x");
// -> var field = $$StaticTable_0.result;
```
Even when compile-time resolution is not possible, dynamic optimization through `Memoization` is applied.  

Next, when the type can be resolved at compile time, it is replaced with a function using generic arguments:  
```.cs
var field = typeof(Vector3).GetFieldFast(name);
// -> var field = REReflection.GetFieldFast<Vector3>(name);
```
Since `Memoization` operates faster with fewer arguments, this optimization speeds up processing.

Furthermore, `FieldInfo.GetValue` methods perform special optimizations.
For instance fields, they access fields quickly by using offset addresses.
For static fields, they manipulate variables directly by obtaining their addresses.
In addition to fast processing, they avoid boxing by not going through the `object` type.

`MethodBase.Invoke` methods use native function pointers for processing.
This allows for direct calls and also avoids boxing.

These techniques have succeeded in significantly speeding up reflection operations.
