using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetAllValidFingerprintsCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: fingerprints json string.</param>
        /// <param name="onError"></param>
        public GetAllValidFingerprintsCallback(Action<string> onSuccess, Action<LockError> onError)
            : base("GetAllValidFingerprintCallback", onSuccess, onError)
        { }

        public void onGetAllFingerprintsSuccess(string fingerprints)
        {
            OnSuccessAction(fingerprints);
        }
    }
}
