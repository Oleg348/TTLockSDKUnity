using System;

namespace OrbitaTech.TTLockUnity
{
    public class DeleteFingerprintCallback : TTLockLockCallback<Action>
    {
        public DeleteFingerprintCallback(Action onSuccess, Action<LockError> onError)
            : base("DeleteFingerprintCallback", onSuccess, onError)
        { }

        public void onDeleteFingerprintSuccess()
        {
            OnSuccessAction();
        }
    }
}
