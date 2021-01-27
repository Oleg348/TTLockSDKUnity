using System;

namespace OrbitaTech.TTLockUnity
{
    public class ResetAllPasscodesCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: new lock data.</param>
        /// <param name="onFail"></param>
        public ResetAllPasscodesCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("ResetPasscodeCallback", onSuccess, onFail)
        { }

        public void onResetPasscodeSuccess(string lockData)
        {
            OnSuccessAction(lockData);
        }
    }
}
