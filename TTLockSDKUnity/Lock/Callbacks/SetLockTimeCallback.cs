using System;

namespace OrbitaTech.TTLockUnity
{
    public class SetLockTimeCallback : TTLockLockCallback<Action>
    {
        public SetLockTimeCallback(Action onSuccess, Action<LockError> onFail)
            : base("SetLockTimeCallback", onSuccess, onFail)
        { }

        public void onSetTimeSuccess()
        {
            OnSuccessAction();
        }
    }
}
