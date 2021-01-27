using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class InitGatewayCallback : TTLockGatewayCallback<Action<GatewayRouterBTDeviceInfo>>
    {
        public InitGatewayCallback(Action<GatewayRouterBTDeviceInfo> onSuccess, Action<GatewayError> onFail)
            : base("InitGatewayCallback", onSuccess, onFail)
        { }

        public void onInitGatewaySuccess(AndroidJavaObject deviceInfo)
        {
            OnSuccessAction(new GatewayRouterBTDeviceInfo(deviceInfo));
        }
    }
}