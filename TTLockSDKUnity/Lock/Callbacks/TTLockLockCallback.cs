using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public abstract class TTLockLockCallback<SuccessActionType> : TTLockCallbackBase<SuccessActionType, Action<LockError>>
        where SuccessActionType : Delegate
    {
        private const string NamespaceWithDotInTheEnd = "com.ttlock.bl.sdk.callback.";

        protected TTLockLockCallback(
            string javaClassName,
            SuccessActionType onSuccess,
            Action<LockError> onError
        )
            : base(NamespaceWithDotInTheEnd, javaClassName, onSuccess, onError)
        { }

        public void onFail(AndroidJavaObject error)
        {
            OnFailAction(new LockError(error));
        }
    }
}