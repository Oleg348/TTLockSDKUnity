using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
#pragma warning disable RCS1058 // Use compound assignment.
#pragma warning disable IDE0074 // Use compound assignment
    public class BTDeviceInfo : JavaProxy
    {
        private string _mac;
        private bool? _isInDfuMode;
        private bool? _isRemoteControllable;
        private sbyte? _protocolType;
        private sbyte? _protocolVersion;

        internal BTDeviceInfo(AndroidJavaObject javaProxy)
            : base(javaProxy)
        { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="mac"></param>
        /// <param name="isInDfuMode"></param>
        /// <param name="isRemoteControllable"></param>
        /// <param name="protocolType"></param>
        /// <param name="protocolVersion"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="mac"/> is null
        /// </exception>
        public BTDeviceInfo(
            string mac,
            bool isInDfuMode,
            bool isRemoteControllable,
            sbyte protocolType,
            sbyte protocolVersion
        )
        {
            _mac = mac.IsNotNull(nameof(mac));
            _isInDfuMode = isInDfuMode;
            _isRemoteControllable = isRemoteControllable;
            _protocolType = protocolType;
            _protocolVersion = protocolVersion;
        }

        public string Mac => _mac ?? (_mac = Proxy.Call<string>("getAddress"));

        /// <summary>
        /// Whether device is in firmware update mode.
        /// </summary>
        public bool IsInDfuMode => (_isInDfuMode ?? (_isInDfuMode = Proxy.Call<bool>("isDfuMode"))).Value;

        public bool IsRemoteControllable => (_isRemoteControllable ?? (_isRemoteControllable = Proxy.Call<bool>("isRemoteControlDevice"))).Value;

        public sbyte ProtocolType => (_protocolType ?? (_protocolType = Proxy.Call<sbyte>("getProtocolType"))).Value;

        public sbyte ProtocolVersion => (_protocolVersion ?? (_protocolVersion = Proxy.Call<sbyte>("getProtocolVersion"))).Value;
    }
#pragma warning restore IDE0074 // Use compound assignment
#pragma warning restore RCS1058 // Use compound assignment.
}