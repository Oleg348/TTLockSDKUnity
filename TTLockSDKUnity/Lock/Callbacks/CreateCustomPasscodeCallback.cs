using System;

namespace OrbitaTech.TTLockUnity
{
    public class CreateCustomPasscodeCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: created pass code.</param>
        /// <param name="onFail"></param>
        public CreateCustomPasscodeCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("CreateCustomPasscodeCallback", onSuccess, onFail)
        { }

        public void onCreateCustomPasscodeSuccess(string passcode)
        {
            OnSuccessAction(passcode);
        }
    }
}
