using System;

namespace OrbitaTech.TTLockUnity
{
    public class ResetEKeyCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: new lock data.</param>
        /// <param name="onFail"></param>
        public ResetEKeyCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("ResetKeyCallback", onSuccess, onFail)
        { }

        public void onResetKeySuccess(string lockData)
        {
            OnSuccessAction(lockData);
        }
    }
}
