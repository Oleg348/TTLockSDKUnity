using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetLockTimeCallback : TTLockLockCallback<Action<DateTime>>
    {
        public GetLockTimeCallback(Action<DateTime> onSuccess, Action<LockError> onFail)
            : base("GetLockTimeCallback", onSuccess, onFail)
        { }

        public void onGetLockTimeSuccess(long lockTime)
        {
            OnSuccessAction(lockTime.GetDateTimeFromUnixMilliseconds());
        }
    }
}
