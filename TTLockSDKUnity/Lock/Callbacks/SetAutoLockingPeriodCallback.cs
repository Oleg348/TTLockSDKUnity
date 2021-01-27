using System;

namespace OrbitaTech.TTLockUnity
{
    public class SetAutoLockingPeriodCallback : TTLockLockCallback<Action>
    {
        public SetAutoLockingPeriodCallback(Action onSuccess, Action<LockError> onFail)
            : base("SetAutoLockingPeriodCallback", onSuccess, onFail)
        { }

        public void onSetAutoLockingPeriodSuccess()
        {
            OnSuccessAction();
        }
    }
}
