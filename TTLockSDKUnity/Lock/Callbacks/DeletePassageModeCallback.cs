using System;

namespace OrbitaTech.TTLockUnity
{
    public class DeletePassageModeCallback : TTLockLockCallback<Action>
    {
        public DeletePassageModeCallback(Action onSuccess, Action<LockError> onFail)
            : base("DeletePassageModeCallback", onSuccess, onFail)
        { }

        public void onDeletePassageModeSuccess()
        {
            OnSuccessAction();
        }
    }
}
