using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetLockMuteModeStateCallback : TTLockLockCallback<Action<bool>>
    {
        public GetLockMuteModeStateCallback(Action<bool> onSuccess, Action<LockError> onError)
            : base("GetLockMuteModeStateCallback", onSuccess, onError)
        { }

        public void onGetMuteModeStateSuccess(bool isEnabled)
        {
            OnSuccessAction(isEnabled);
        }
    }
}
