using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class ControlLockResult : JavaProxy
    {
        private int? _id;
        private int? _action;
        private int? _battery;
        private DateTime? _lockTime;

        public ControlLockResult(AndroidJavaObject proxy)
            : base(proxy)
        { }

        public ControlLockResult(int id, int action, int battery, DateTime lockTime)
        {
            _id = id;
            _action = action;
            _battery = battery;
            _lockTime = lockTime;
        }

        public int Id => _id ?? (_id = Proxy?.Call<int>("getUniqueid") ?? 0).Value;

        public int Action => _action ?? (_action = Proxy?.Call<int>("getControlAction") ?? 0).Value;

        public int BatteryLevel => _battery ?? (_battery = Proxy?.Call<int>("getBattery") ?? 0).Value;

        public DateTime LockTime => _lockTime
            ?? (_lockTime = (Proxy?.Call<long>("getLockTime") ?? 0L).GetDateTimeFromUnixMilliseconds()).Value;
    }
}
