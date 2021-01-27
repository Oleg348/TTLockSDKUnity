using System;

namespace OrbitaTech.TTLockUnity
{
    public class DeletePasscodeCallback : TTLockLockCallback<Action>
    {
        public DeletePasscodeCallback(Action onSuccess, Action<LockError> onFail)
            : base("DeletePasscodeCallback", onSuccess, onFail)
        { }

        public void onDeletePasscodeSuccess()
        {
            OnSuccessAction();
        }
    }
}
