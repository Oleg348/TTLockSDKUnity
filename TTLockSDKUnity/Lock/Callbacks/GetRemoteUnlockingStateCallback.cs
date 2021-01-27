using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetRemoteUnlockingStateCallback : TTLockLockCallback<Action<bool>>
    {
        public GetRemoteUnlockingStateCallback(Action<bool> onSuccess, Action<LockError> onError)
            : base("GetRemoteUnlockStateCallback", onSuccess, onError)
        { }

        public void onGetRemoteUnlockSwitchStateSuccess(bool isEnabled)
        {
            OnSuccessAction(isEnabled);
        }
    }
}
