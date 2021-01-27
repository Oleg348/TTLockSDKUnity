using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class ScanGatewaysCallBack : TTLockCallbackBase<Action<BTDeviceInfo>, Action<int>>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="onRouterFound"></param>
        /// <param name="onError">Parameter: error code.</param>
        public ScanGatewaysCallBack(
            Action<BTDeviceInfo> onRouterFound,
            Action<int> onError
        )
            : base("com.ttlock.bl.sdk.gateway.callback.", "ScanGatewayCallback", onRouterFound, onError)
        { }

        public void onScanGatewaySuccess(AndroidJavaObject bleDevice)
        {
            OnSuccessAction(new BTDeviceInfo(bleDevice));
        }

        public void onScanFailed(int errorCode)
        {
            OnFailAction(errorCode);
        }
    }
}