using System;

namespace OrbitaTech.TTLockUnity
{
    public class WifiInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="wifiName"></param>
        /// <param name="wifiPassword"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="wifiName"/> is null
        /// -or-
        /// <paramref name="wifiPassword"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="wifiName"/> or <paramref name="wifiPassword"/> is empty or contains only whitespaces
        /// </exception>
        public WifiInfo(string wifiName, string wifiPassword)
        {
            wifiName.IsNotNull(nameof(wifiName));
            wifiPassword.IsNotNull(nameof(wifiPassword));

            wifiName.IsValid(n => !string.IsNullOrWhiteSpace(n), nameof(wifiName), "WIFI name must be non empty and contains not only whitespaces");
            wifiPassword.IsValid(n => !string.IsNullOrWhiteSpace(n), nameof(wifiPassword), "WIFI password must be non empty and contains not only whitespaces");

            WifiName = wifiName;
            WifiPassword = wifiPassword;
        }

        public string WifiName { get; }

        public string WifiPassword { get; }
    }
}