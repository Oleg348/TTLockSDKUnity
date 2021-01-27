using System;

namespace OrbitaTech.TTLockUnity
{
    public class LockInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="lockMac"></param>
        /// <param name="lockData"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lockMac"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="lockMac"/> is empty or contains only whitespaces.
        /// </exception>
        public LockInfo(string lockMac, string lockData = null)
        {
            lockMac.IsNotNull(nameof(lockMac));
            lockMac.IsValid(m => !string.IsNullOrWhiteSpace(m), nameof(lockMac), "MAC адрес не может быть пустым");

            LockMac = lockMac;
            LockData = lockData;
        }

        public string LockMac { get; }

        public string LockData { get; set; }
    }
}
