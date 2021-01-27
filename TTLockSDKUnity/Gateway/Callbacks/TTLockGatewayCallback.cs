using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public abstract class TTLockGatewayCallback<SuccessActionType> : TTLockCallbackBase<SuccessActionType, Action<GatewayError>>
        where SuccessActionType : Delegate
    {
        private const string NamespaceWithDotInTheEnd = "com.ttlock.bl.sdk.gateway.callback.";

        protected TTLockGatewayCallback(
            string javaClassName,
            SuccessActionType onSuccess,
            Action<GatewayError> onError
        )
            : base(NamespaceWithDotInTheEnd, javaClassName, onSuccess, onError)
        { }

        public void onFail(AndroidJavaObject error)
        {
            OnFailAction(new GatewayError(error));
        }
    }
}