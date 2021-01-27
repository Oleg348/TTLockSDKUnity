using System;

namespace OrbitaTech.TTLockUnity
{
    public class AddICCardCallback : TTLockLockCallback<Action<long>>
    {
        private readonly Action _onEnterAddMode;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onEnterAddMode"></param>
        /// <param name="onSuccess">Parameter: card number.</param>
        /// <param name="onError"></param>
        public AddICCardCallback(Action onEnterAddMode, Action<long> onSuccess, Action<LockError> onError)
            : base("AddICCardCallback", onSuccess, onError)
        {
            _onEnterAddMode = onEnterAddMode.IsNotNull(nameof(onEnterAddMode));
        }

        public void onEnterAddMode()
        {
            _onEnterAddMode();
        }

        public void onAddICCardSuccess(long cardNumber)
        {
            OnSuccessAction(cardNumber);
        }
    }
}
