using System;

namespace OrbitaTech.TTLockUnity
{
    public class InitLockCallback : TTLockLockCallback<Action<string>>
    {
        public InitLockCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("InitLockCallback", onSuccess, onFail)
        { }

        public void onInitLockSuccess(string lockData)
        {
            OnSuccessAction(lockData);
        }
    }
}
