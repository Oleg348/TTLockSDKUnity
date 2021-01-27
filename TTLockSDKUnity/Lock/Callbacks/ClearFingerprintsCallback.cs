using System;

namespace OrbitaTech.TTLockUnity
{
    public class ClearFingerprintsCallback : TTLockLockCallback<Action>
    {
        public ClearFingerprintsCallback(Action onSuccess, Action<LockError> onError)
            : base("ClearAllFingerprintCallback", onSuccess, onError)
        { }

        public void onClearAllFingerprintSuccess()
        {
            OnSuccessAction();
        }
    }
}
