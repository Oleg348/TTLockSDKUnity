using System;

namespace OrbitaTech.TTLockUnity
{
    public class ModifyPasscodeCallback : TTLockLockCallback<Action>
    {
        public ModifyPasscodeCallback(Action onSuccess, Action<LockError> onFail)
            : base("ModifyPasscodeCallback", onSuccess, onFail)
        { }

        public void onModifyPasscodeSuccess()
        {
            OnSuccessAction();
        }
    }
}
