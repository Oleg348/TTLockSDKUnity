using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class ScanLockCallback : TTLockLockCallback<Action<BTDeviceInfo>>
    {
        public ScanLockCallback(Action<BTDeviceInfo> onLockFound, Action<LockError> onError)
            : base("ScanLockCallback", onLockFound, onError)
        { }

        public void onScanLockSuccess(AndroidJavaObject lockDevice)
        {
            OnSuccessAction(new BTDeviceInfo(lockDevice));
        }
    }
}
