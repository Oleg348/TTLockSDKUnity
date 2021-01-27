using System;

namespace OrbitaTech.TTLockUnity
{
    public class ModifyFingerprintPeriodCallback : TTLockLockCallback<Action>
    {
        public ModifyFingerprintPeriodCallback(Action onSuccess, Action<LockError> onError)
            : base("ModifyFingerprintPeriodCallback", onSuccess, onError)
        { }

        public void onModifyPeriodSuccess()
        {
            OnSuccessAction();
        }
    }
}
