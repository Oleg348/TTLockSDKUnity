using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class GatewayBTHandler : IGatewayBTHandler
    {
        private static readonly AndroidJavaClass __gatewayClientClass = new AndroidJavaClass("com.ttlock.bl.sdk.gateway.api.GatewayClient");
        private static readonly AndroidJavaObject __gatewayClientObj = __gatewayClientClass.CallStatic<AndroidJavaObject>("getDefault");

        public bool IsBTEnabled(AndroidJavaObject context)
        {
            context.IsNotNull(nameof(context));

            return __gatewayClientObj.Call<bool>("isBLEEnabled", context);
        }

        public void RequestBTEnable(AndroidJavaObject activity)
        {
            activity.IsNotNull(nameof(activity));

            __gatewayClientObj.Call("requestBleEnable", activity);
        }

        public void PrepareBT(AndroidJavaObject context)
        {
            context.IsNotNull(nameof(context));

            __gatewayClientObj.Call("prepareBTService", context);
        }

        public void StopBT()
        {
            __gatewayClientObj.Call("stopBTService");
        }

        public void ScanGateways(ScanGatewaysCallBack callback)
        {
            callback.IsNotNull(nameof(callback));

            __gatewayClientObj.Call("startScanGateway", callback);
        }

        public void StopScanGateways()
        {
            __gatewayClientObj.Call("stopScanGateway");
        }

        public void ConnectToGateway(BTDeviceInfo router, ConnectGatewayCallBack callback)
        {
            callback.IsNotNull(nameof(callback));
            router.IsNotNull(nameof(router));

            __gatewayClientObj.Call("connectGateway", router.Mac, callback);
        }

        public void DisconnectGateway()
        {
            __gatewayClientObj.Call("disconnectGateway");
        }

        public void InitGateway(
            BTDeviceInfo router,
            WifiInfo wifiInfo,
            UserInfo user,
            InitGatewayCallback callback
        )
        {
            router.IsNotNull(nameof(router));
            wifiInfo.IsNotNull(nameof(wifiInfo));
            user.IsNotNull(nameof(user));
            callback.IsNotNull(nameof(callback));

            var gatewayConfig = new AndroidJavaObject("com.ttlock.bl.sdk.gateway.model.ConfigureGatewayInfo");
            gatewayConfig.Set("uid", user.Uid);
            gatewayConfig.Set("userPwd", user.MD5Password);
            gatewayConfig.Set("ssid", wifiInfo.WifiName);
            gatewayConfig.Set("wifiPwd", wifiInfo.WifiPassword);
            gatewayConfig.Set("plugName", router.Mac);

            __gatewayClientObj.Call("initGateway", gatewayConfig, callback);
        }

        public void EnterGatewayToDFUMode(string gatewayMac, GatewayEnterDfuModeCallback callback)
        {
            gatewayMac.IsNotNull(nameof(gatewayMac));
            callback.IsNotNull(nameof(callback));

            __gatewayClientObj.Call("enterDfu", gatewayMac, callback);
        }
    }
}