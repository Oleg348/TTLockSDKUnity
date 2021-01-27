using System;

namespace OrbitaTech.TTLockUnity
{
    public class GetOperationsLogsCallback : TTLockLockCallback<Action<string>>
    {
        public GetOperationsLogsCallback(Action<string> onSuccess, Action<LockError> onError)
            : base("GetOperationLogCallback", onSuccess, onError)
        { }

        public void onGetLogSuccess(string operationsString)
        {
            OnSuccessAction(operationsString);
        }
    }
}
