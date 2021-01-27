using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetAllValidPasscodesCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: pass codes json string.</param>
        /// <param name="onFail"></param>
        public GetAllValidPasscodesCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("GetAllValidPasscodeCallback", onSuccess, onFail)
        { }

        public void onGetAllValidPasscodeSuccess(string passcodes)
        {
            OnSuccessAction(passcodes);
        }
    }
}
