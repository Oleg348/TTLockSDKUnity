using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetAllValidICCardsCallback : TTLockLockCallback<Action<string>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onSuccess">Parameter: IC cards json string.</param>
        /// <param name="onError"></param>
        public GetAllValidICCardsCallback(Action<string> onSuccess, Action<LockError> onError)
            : base("GetAllValidICCardCallback", onSuccess, onError)
        { }

        public void onGetAllValidICCardSuccess(string icCards)
        {
            OnSuccessAction(icCards);
        }
    }
}
