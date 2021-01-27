using System;

namespace OrbitaTech.TTLockUnity
{
    public class UserInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="md5Password">User password md5 converted string (32 chars).</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="md5Password"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="md5Password"/> is not 32 chars.
        /// </exception>
        public UserInfo(int uid, string md5Password)
        {
            Uid = uid;

            md5Password.IsNotNull(nameof(md5Password));
            md5Password.IsValid(p => p.Length == 32, nameof(md5Password), "MD5 encrypted user password must contains 32 chars");
            MD5Password = md5Password.ToLowerInvariant();
        }

        public int Uid { get; }

        public string MD5Password { get; }
    }
}