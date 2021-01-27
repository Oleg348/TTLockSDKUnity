using System;

namespace OrbitaTech.TTLockUnity
{
    public class SetRemoteUnlockingStateCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: new lock data.</param>
        /// <param name="onError"></param>
        public SetRemoteUnlockingStateCallback(Action<string> onSuccess, Action<LockError> onError)
            : base("SetRemoteUnlockSwitchCallback", onSuccess, onError)
        { }

        public void onSetRemoteUnlockSwitchSuccess(string lockData)
        {
            OnSuccessAction(lockData);
        }
    }
}
