using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class ConnectGatewayCallBack : TTLockCallbackBase<Action<BTDeviceInfo>, Action>
    {
        public ConnectGatewayCallBack(
            Action<BTDeviceInfo> onConnect,
            Action onDisconnect
        )
            : base("com.ttlock.bl.sdk.gateway.callback.", "ConnectCallback", onConnect, onDisconnect)
        { }

        public void onConnectSuccess(AndroidJavaObject bleDevice)
        {
            OnSuccessAction(new BTDeviceInfo(bleDevice));
        }

        public void onDisconnected()
        {
            OnFailAction();
        }
    }
}