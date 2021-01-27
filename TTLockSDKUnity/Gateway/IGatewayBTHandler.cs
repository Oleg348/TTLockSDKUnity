using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    /// <summary>
    /// Gateway bluetooth service.
    /// </summary>
    public interface IGatewayBTHandler
    {
        /// <summary>
        /// Check if BT is enabled.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        bool IsBTEnabled(AndroidJavaObject context);

        /// <summary>
        /// Request BT enabling.
        /// </summary>
        /// <param name="activity"></param>
        /// <exception cref="ArgumentNullException"/>
        void RequestBTEnable(AndroidJavaObject activity);

        /// <summary>
        /// Prepare BT service.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"/>
        void PrepareBT(AndroidJavaObject context);

        /// <summary>
        /// Stop BT service.
        /// </summary>
        void StopBT();

        /// <summary>
        /// Start scanning for gateways.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        void ScanGateways(ScanGatewaysCallBack callback);

        /// <summary>
        /// Stop scanning for gateways.
        /// </summary>
        void StopScanGateways();

        /// <summary>
        /// Connect to gateway.
        /// </summary>
        /// <param name="router"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="router"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="router"/> must be received from <see cref="ScanGateways(ScanGatewaysCallBack)"/> method
        /// </exception>
        void ConnectToGateway(BTDeviceInfo router, ConnectGatewayCallBack callback);

        /// <summary>
        /// Disconnect gateway.
        /// </summary>
        void DisconnectGateway();

        /// <summary>
        /// Initialize gateway.
        /// </summary>
        /// <param name="router"></param>
        /// <param name="wifiInfo"></param>
        /// <param name="user"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="router"/> is null
        /// -or-
        /// <paramref name="wifiInfo"/> is null
        /// -or-
        /// <paramref name="user"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        void InitGateway(
            BTDeviceInfo router,
            WifiInfo wifiInfo,
            UserInfo user,
            InitGatewayCallback callback
        );

        /// <summary>
        /// Enter gateway to Device Firmware Update mode.
        /// </summary>
        /// <param name="gatewayMac"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="gatewayMac"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        void EnterGatewayToDFUMode(string gatewayMac, GatewayEnterDfuModeCallback callback);
    }
}
