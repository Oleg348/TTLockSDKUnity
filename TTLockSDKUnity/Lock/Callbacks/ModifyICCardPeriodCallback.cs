using System;

namespace OrbitaTech.TTLockUnity
{
    public class ModifyICCardPeriodCallback : TTLockLockCallback<Action>
    {
        public ModifyICCardPeriodCallback(Action onSuccess, Action<LockError> onError)
            : base("ModifyICCardPeriodCallback", onSuccess, onError)
        { }

        public void onModifyICCardPeriodSuccess()
        {
            OnSuccessAction();
        }
    }
}
