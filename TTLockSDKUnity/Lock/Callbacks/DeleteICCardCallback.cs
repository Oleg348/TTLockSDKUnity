using System;

namespace OrbitaTech.TTLockUnity
{
    public class DeleteICCardCallback : TTLockLockCallback<Action>
    {
        public DeleteICCardCallback(Action onSuccess, Action<LockError> onError)
            : base("DeleteICCardCallback", onSuccess, onError)
        { }

        public void onDeleteICCardSuccess()
        {
            OnSuccessAction();
        }
    }
}
