using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetBatteryLevelCallback : TTLockLockCallback<Action<int>>
    {
        public GetBatteryLevelCallback(Action<int> onSuccess, Action<LockError> onFail)
            : base("GetBatteryLevelCallback", onSuccess, onFail)
        { }

        public void onGetBatteryLevelSuccess(int level)
        {
            OnSuccessAction(level);
        }
    }
}
