using System;

namespace OrbitaTech.TTLockUnity
{
    public class AddFingerprintCallback : TTLockLockCallback<Action<int>>
    {
        private readonly Action<int> _onFingerPrintAdded;
        private readonly Action<long> _onFinished;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onStart">Parameter: total finger attaching count needed.</param>
        /// <param name="onFingerPrintAdded">Parameter: current attaching counts.</param>
        /// <param name="onFinished">Parameter: fingerprint number.</param>
        /// <param name="onError"></param>
        public AddFingerprintCallback(Action<int> onStart, Action<int> onFingerPrintAdded, Action<long> onFinished, Action<LockError> onError)
            : base("AddFingerprintCallback", onStart, onError)
        {
            _onFingerPrintAdded = onFingerPrintAdded.IsNotNull(nameof(onFingerPrintAdded));
            _onFinished = onFinished.IsNotNull(nameof(onFinished));
        }

        public void onEnterAddMode(int totalCount)
        {
            OnSuccessAction(totalCount);
        }

        public void onCollectFingerprint(int currentCount)
        {
            _onFingerPrintAdded(currentCount);
        }

        public void onAddFingerpintFinished(long fingerPrintNumber)
        {
            _onFinished(fingerPrintNumber);
        }
    }
}
