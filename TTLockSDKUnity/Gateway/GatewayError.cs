using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
#pragma warning disable RCS1058 // Use compound assignment.
#pragma warning disable IDE0074 // Use compound assignment
    public class GatewayError : JavaProxy
    {
        private int? _code;
        private string _msg;

        internal GatewayError(AndroidJavaObject proxy)
            : base(proxy)
        { }

        public int Code => _code ?? (_code = Proxy.Call<int>("getErrorCode")).Value;

        public string Message => _msg ?? (_msg = Proxy.Call<string>("getDescription"));
    }
#pragma warning restore IDE0074 // Use compound assignment
#pragma warning restore RCS1058 // Use compound assignment.
}