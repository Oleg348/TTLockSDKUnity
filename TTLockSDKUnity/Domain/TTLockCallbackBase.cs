using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public abstract class TTLockCallbackBase<SuccessActionType, FailedActionType>
            : AndroidJavaProxy
        where SuccessActionType : Delegate
        where FailedActionType : Delegate
    {
        protected readonly SuccessActionType OnSuccessAction;
        protected readonly FailedActionType OnFailAction;

        protected TTLockCallbackBase(
            string javaClassNamespaceWithDotInTheEnd,
            string javaClassName,
            SuccessActionType onSuccessAction,
            FailedActionType onFailAction
        )
            : base(javaClassNamespaceWithDotInTheEnd + javaClassName)
        {
            onSuccessAction.IsNotNull(nameof(onSuccessAction));
            onFailAction.IsNotNull(nameof(onFailAction));

            OnSuccessAction = onSuccessAction;
            OnFailAction = onFailAction;
        }
    }
}