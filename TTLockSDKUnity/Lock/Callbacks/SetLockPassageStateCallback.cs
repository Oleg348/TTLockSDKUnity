using System;

namespace OrbitaTech.TTLockUnity
{
    public class SetLockPassageStateCallback : TTLockLockCallback<Action>
    {
        public SetLockPassageStateCallback(Action onSuccess, Action<LockError> onFail)
            : base("SetPassageModeCallback", onSuccess, onFail)
        { }

        public void onSetPassageModeSuccess()
        {
            OnSuccessAction();
        }
    }
}
