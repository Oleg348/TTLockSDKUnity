using System;

namespace OrbitaTech.TTLockUnity
{
    public class GatewayEnterDfuModeCallback : TTLockGatewayCallback<Action>
    {
        public GatewayEnterDfuModeCallback(Action successAction, Action<GatewayError> failAction)
            : base("EnterDfuCallback", successAction, failAction)
        { }

        public void onEnterDfuSuccess()
        {
            OnSuccessAction();
        }
    }
}