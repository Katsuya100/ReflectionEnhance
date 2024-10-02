using System;
using System.Collections;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance
{
    public abstract class AsyncHandle<T> : IEnumerator<T>
    {
        private bool _isDone = false;
        public bool IsDone => _isDone;
        private T _result = default;
        public T Result => _result;

        T IEnumerator<T>.Current => _result;
        object IEnumerator.Current => _result;

        void IDisposable.Dispose()
        {
        }

        void IEnumerator.Reset()
        {
        }

        bool IEnumerator.MoveNext()
        {
            return !IsDone;
        }

        protected void SetResultInternal(T result)
        {
            _isDone = true;
            _result = result;
        }
    }
}
