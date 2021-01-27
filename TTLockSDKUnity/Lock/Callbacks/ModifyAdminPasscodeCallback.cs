using System;

namespace OrbitaTech.TTLockUnity
{
    public class ModifyAdminPasscodeCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: created pass code.</param>
        /// <param name="onFail"></param>
        public ModifyAdminPasscodeCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("ModifyAdminPasscodeCallback", onSuccess, onFail)
        { }

        public void onModifyAdminPasscodeSuccess(string newPasscode)
        {
            OnSuccessAction(newPasscode);
        }
    }
}
