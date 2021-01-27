using System;

namespace OrbitaTech.TTLockUnity
{
    public class ResetLockCallback : TTLockLockCallback<Action>
    {
        public ResetLockCallback(Action onSuccess, Action<LockError> onFail)
            : base("ResetLockCallback", onSuccess, onFail)
        { }

        public void onResetLockSuccess()
        {
            OnSuccessAction();
        }
    }
}
