using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    /// <summary>
    /// Gateway router bluetooth device info.
    /// </summary>
    public class GatewayRouterBTDeviceInfo : JavaProxy
    {
        private string _model;
        private string _hardwareRevision;
        private string _firmwareRevision;

        internal GatewayRouterBTDeviceInfo(AndroidJavaObject proxy)
            : base(proxy)
        { }

        public GatewayRouterBTDeviceInfo(
            string model,
            string hardwareRevision,
            string firmwareRevision
        )
        {
            _model = model;
            _hardwareRevision = hardwareRevision;
            _firmwareRevision = firmwareRevision;
        }

        public string Model => _model ?? (_model = Proxy?.Call<string>("getModelNum"));

        public string HardwareRevision => _hardwareRevision ?? (_hardwareRevision = Proxy?.Call<string>("getHardwareRevision"));

        public string FirmwareRevision => _firmwareRevision ?? (_firmwareRevision = Proxy?.Call<string>("getFirmwareRevision"));
    }
}