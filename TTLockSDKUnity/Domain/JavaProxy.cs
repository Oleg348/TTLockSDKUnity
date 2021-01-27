using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public abstract class JavaProxy : IDisposable
    {
        public readonly AndroidJavaObject Proxy;

        private bool _disposedValue;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="proxy"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="proxy"/> is null
        /// </exception>
        protected JavaProxy(AndroidJavaObject proxy)
        {
            Proxy = proxy.IsNotNull(nameof(proxy));
        }

        protected JavaProxy()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Proxy?.Dispose();
                }
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~JavaProxy()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}