using System;

namespace OrbitaTech.TTLockUnity
{
    public class ClearPassageModeCallback : TTLockLockCallback<Action>
    {
        public ClearPassageModeCallback(Action onSuccess, Action<LockError> onFail)
            : base("ClearPassageModeCallback", onSuccess, onFail)
        { }

        public void onClearPassageModeSuccess()
        {
            OnSuccessAction();
        }
    }
}
