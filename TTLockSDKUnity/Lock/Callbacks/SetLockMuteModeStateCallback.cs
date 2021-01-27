using System;

namespace OrbitaTech.TTLockUnity
{
    public class SetLockMuteModeStateCallback : TTLockLockCallback<Action<bool>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: is muted now.</param>
        /// <param name="onError"></param>
        public SetLockMuteModeStateCallback(Action<bool> onSuccess, Action<LockError> onError)
            : base("SetLockMuteModeCallback", onSuccess, onError)
        { }

        public void onSetMuteModeSuccess(bool isMuted)
        {
            OnSuccessAction(isMuted);
        }
    }
}
