using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
#pragma warning disable IDE0074 // Use compound assignment
#pragma warning disable RCS1058 // Use compound assignment.
    public class LockError : JavaProxy
    {
        private string _command;
        private string _lockName;
        private string _lockMac;
        private DateTime? _date;
        private int? _errCode;
        private string _errMsg;
        private string _errDescription;

        internal LockError(AndroidJavaObject proxy)
            : base(proxy)
        { }

        public string Command => _command ?? (_command = Proxy.Call<string>("getCommand"));

        public string LockName => _lockName ?? (_lockName = Proxy.Call<string>("getLockname"));

        public string LockMac => _lockMac ?? (_lockMac = Proxy.Call<string>("getLockmac"));

        public DateTime Date => _date
            ?? (_date = Proxy.Call<long>("getDate").GetDateTimeFromUnixMilliseconds()).Value;

        public int ErrorCode => _errCode ?? (_errCode = Proxy.Call<int>("getIntErrorCode")).Value;

        public string ErrorMessage => _errMsg ?? (_errMsg = Proxy.Call<string>("getErrorMsg"));

        public string ErrorDescription => _errDescription ?? (_errDescription = Proxy.Call<string>("getDescription") ?? "");
    }
#pragma warning restore RCS1058 // Use compound assignment.
#pragma warning restore IDE0074 // Use compound assignment
}