using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class ControlLockCallback : TTLockLockCallback<Action<ControlLockResult>>
    {
        public ControlLockCallback(Action<ControlLockResult> onSuccess, Action<LockError> onFail)
            : base("ControlLockCallback", onSuccess, onFail)
        { }

        public void onControlLockSuccess(AndroidJavaObject javaObject)
        {
            OnSuccessAction(new ControlLockResult(javaObject));
        }
    }
}
