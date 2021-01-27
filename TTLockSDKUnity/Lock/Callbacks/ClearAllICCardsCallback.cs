using System;

namespace OrbitaTech.TTLockUnity
{
    public class ClearAllICCardsCallback : TTLockLockCallback<Action>
    {
        public ClearAllICCardsCallback(Action onSuccess, Action<LockError> onError)
            : base("ClearAllICCardCallback", onSuccess, onError)
        { }

        public void onClearAllICCardSuccess()
        {
            OnSuccessAction();
        }
    }
}
