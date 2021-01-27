using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetLockPassageStateCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: passage mode config json string.</param>
        /// <param name="onFail"></param>
        public GetLockPassageStateCallback(Action<string> onSuccess, Action<LockError> onFail)
            : base("GetPassageModeCallback", onSuccess, onFail)
        { }

        public void onGetPassageModeSuccess(string data)
        {
            OnSuccessAction(data);
        }
    }
}
