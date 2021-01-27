using System;
using System.Linq;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    public class LockBTHandler : ILockBTHandler
    {
        #region Private fields

        private static readonly AndroidJavaClass __handlerClass = new AndroidJavaClass("com.ttlock.bl.sdk.api.TTLockClient");
        private static readonly AndroidJavaObject __handlerObject = __handlerClass.CallStatic<AndroidJavaObject>("getDefault");

        private LockInfo _lockToOperate;

        #endregion Private fields

        #region Private properties

        private string _LockData => LockToOperate.LockData;
        private string _LockMac => LockToOperate.LockMac;

        #endregion Private properties

        #region Public properties

        public LockInfo LockToOperate
        {
            get => _lockToOperate ?? throw Error.InvalidOperation($"Property {LockToOperate} wasn't initialized.");
            set
            {
                value.IsNotNull(nameof(value));
                if (string.IsNullOrEmpty(value.LockData))
                {
                    throw Argument.Invalid(nameof(value.LockData), "Lock data can't be null");
                }
                _lockToOperate = value;
            }
        }

        #endregion Public properties

        #region Private methods

        private static AndroidJavaObject __GetPassageConfigJavaObj(PassageModeConfig config)
        {
            var actualPassageType = config.PassageType;
            if (!Enum.IsDefined(typeof(PassageModeType), actualPassageType))
            {
                throw Argument.Invalid(nameof(config.PassageType), $"Некорректный тип проходов ({actualPassageType})");
            }

            var jObj = new AndroidJavaObject("com.ttlock.bl.sdk.entity.PassageModeConfig");
            jObj.Call("setStartDate", config.StartTime);
            jObj.Call("setEndDate", config.EndTime);
            jObj.Call("setEndDate", config.EndTime);
            jObj.Call("setModeType", (int)config.PassageType);
            jObj.Call("setRepeatWeekOrDays", config.AccessiblePeriods.SerializeToJson());
            return jObj;
        }

        private static long __GetTimeForLib(DateTime? value) => value?.GetUnixTimeInMilliseconds() ?? 0L;

        private static void __VerifyPasscode(string passcode)
        {
            passcode.IsNotNull(nameof(passcode));
            passcode.IsValid(p => p.Length > 5 && p.All(char.IsDigit), nameof(passcode), "Пароль должен быть не короче 6 символов и состоять только из цифр");
        }

        private static void __VerifyCardNumber(string cardNumber)
        {
            cardNumber.IsNotNull(nameof(cardNumber));
            cardNumber.IsValid(cn => !string.IsNullOrEmpty(cn) && cn.All(char.IsDigit), nameof(cardNumber), "Номер карты должен быть не пустым и состоять только из цифр");
        }

        private static void __VerifyFingerPrintNumber(string fingerPrintNumber)
        {
            fingerPrintNumber.IsNotNull(nameof(fingerPrintNumber));
            fingerPrintNumber.IsValid(fn => !string.IsNullOrEmpty(fn) && fn.All(char.IsDigit), nameof(fingerPrintNumber), "Номер отпечатка должен быть не пустым и состоять только из цифр");
        }

        #endregion Private methods

        #region Public methods

        #region Common methods

        public void InitializeLock(BTDeviceInfo lockDevice, InitLockCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            lockDevice.IsNotNull(nameof(lockDevice));
            lockDevice.IsValid(ld => !(ld.Proxy is null), nameof(lockDevice), "Device must be received from scan method");

            __handlerObject.Call(
                "initLock",
                lockDevice.Proxy,
                callback
            );
        }

        public bool IsBTEnabled(AndroidJavaObject context)
        {
            context.IsNotNull(nameof(context));

            return __handlerObject.Call<bool>("isBLEEnabled", context);
        }

        public void PrepareBTService(AndroidJavaObject context)
        {
            context.IsNotNull(nameof(context));

            __handlerObject.Call("prepareBTService", context);
        }

        public void RequestBTEnable(AndroidJavaObject activity)
        {
            activity.IsNotNull(nameof(activity));

            __handlerObject.Call("requestBleEnable", activity);
        }

        public void StartScanLocks(ScanLockCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call("startScanLock", callback);
        }

        public void StopBTService()
        {
            __handlerObject.Call("stopBTService");
        }

        public void StopScanLocks()
        {
            __handlerObject.Call("stopScanLock");
        }

        #endregion Common methods

        #region Selected lock operations

        public void CloseLock(ControlLockCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "controlLock",
                (int)ControlAction.Lock,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void OpenLock(ControlLockCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "controlLock",
                (int)ControlAction.Unlock,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ResetLock(ResetLockCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "resetLock",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ResetLockEKey(ResetEKeyCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "resetEkey",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetOperationLogs(OperationsLogsFilter filter, GetOperationsLogsCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            filter.IsValid(f => Enum.IsDefined(typeof(OperationsLogsFilter), f), nameof(filter), "Неизвестный тип фильтра");

            __handlerObject.Call(
                "getOperationLog",
                (int)filter,
                _LockData,
                _LockMac,
                callback
            );
        }

        #region Configuration

        public void GetLockBatteryLevel(GetBatteryLevelCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getBatteryLevel",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetLockMuteModeState(GetLockMuteModeStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getMuteModeState",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetLockRemoteUnlockingState(GetRemoteUnlockingStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getRemoteUnlockSwitchState",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetLockTime(GetLockTimeCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getLockTime",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void SetLockAutolockPeriod(int seconds, SetAutoLockingPeriodCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            seconds.IsValid(s => s >= 0, nameof(seconds), "Задержка закрытия должна быть положительной");

            __handlerObject.Call(
                "setAutomaticLockingPeriod",
                seconds,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void SetLockMuteModeState(bool enable, SetLockMuteModeStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "setMuteMode",
                enable,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void SetLockRemoteUnlockingState(bool enable, SetRemoteUnlockingStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "setRemoteUnlockSwitchState",
                enable,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void SetLockTime(DateTime newTime, SetLockTimeCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "setLockTime",
                __GetTimeForLib(newTime),
                _LockData,
                _LockMac,
                callback
            );
        }

        #endregion Configuration

        #region Pass code

        public void CreateLockCustomPasscode(string passcode, DateTime? startDate, DateTime? endDate, CreateCustomPasscodeCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyPasscode(passcode);

            __handlerObject.Call(
                "createCustomPasscode",
                passcode,
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                _LockData,
                _LockMac,
                callback
            );
        }

        public void DeleteLockPasscode(string passcode, DeletePasscodeCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyPasscode(passcode);

            __handlerObject.Call(
                "deletePasscode",
                passcode,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetLockAllValidPasscodes(GetAllValidPasscodesCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getAllValidPasscodes",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ModifyLockAdminPasscode(string newPasscode, ModifyAdminPasscodeCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyPasscode(newPasscode);

            __handlerObject.Call(
                "modifyAdminPasscode",
                newPasscode,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ModifyLockPasscode(string originalPassocde, string newPasscode, DateTime? startDate, DateTime? endDate, ModifyPasscodeCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyPasscode(originalPassocde);
            if (!string.IsNullOrEmpty(newPasscode))
            {
                __VerifyPasscode(newPasscode);
            }

            __handlerObject.Call(
                "modifyPasscode",
                originalPassocde,
                newPasscode,
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ResetLockAllPasscodes(ResetAllPasscodesCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "resetPasscode",
                _LockData,
                _LockMac,
                callback
            );
        }

        #endregion Pass code

        #region Passage mode

        public void ClearLockPassageMode(ClearPassageModeCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call("clearPassageMode", _LockData, _LockMac, callback);
        }

        public void DeleteLockPassageMode(PassageModeConfig config, DeletePassageModeCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            var cfg = __GetPassageConfigJavaObj(config);
            __handlerObject.Call(
                "deletePassageMode",
                cfg,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetLockPassageMode(GetLockPassageStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getPassageMode",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void SetLockPassageMode(PassageModeConfig config, SetLockPassageStateCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            var cfg = __GetPassageConfigJavaObj(config);
            __handlerObject.Call(
                "setPassageMode",
                cfg,
                _LockData,
                _LockMac,
                callback
            );
        }

        #endregion Passage mode

        #region IC Card

        public void AddLockICCard(DateTime? startDate, DateTime? endDate, AddICCardCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "addICCard",
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ModifyLockICCardPeriod(DateTime? startDate, DateTime? endDate, string cardNumber, ModifyICCardPeriodCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyCardNumber(cardNumber);

            __handlerObject.Call(
                "modifyICCardValidityPeriod",
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                cardNumber,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetAllLockValidICCards(GetAllValidICCardsCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getAllValidICCards",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void DeleteLockICCard(string cardNumber, DeleteICCardCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyCardNumber(cardNumber);

            __handlerObject.Call(
                "deleteICCard",
                cardNumber,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ClearAllLockICCards(ClearAllICCardsCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "clearAllICCard",
                _LockData,
                _LockMac,
                callback
            );
        }

        #endregion IC Card

        #region Fingerprint

        public void AddLockFingerprint(DateTime? startDate, DateTime? endDate, AddFingerprintCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "addFingerprint",
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                _LockData,
                _LockMac,
                callback
            );
        }

        public void GetAllLockValidFingerprints(GetAllValidFingerprintsCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "getAllValidFingerprints",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void DeleteLockFingerprint(string fpNumber, DeleteFingerprintCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyFingerPrintNumber(fpNumber);

            __handlerObject.Call(
                "deleteFingerprint",
                fpNumber,
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ClearAllLockFingerprints(ClearFingerprintsCallback callback)
        {
            callback.IsNotNull(nameof(callback));

            __handlerObject.Call(
                "clearAllFingerprints",
                _LockData,
                _LockMac,
                callback
            );
        }

        public void ModifyLockFingerprintPeriod(DateTime? startDate, DateTime? endDate, string fpNumber, ModifyFingerprintPeriodCallback callback)
        {
            callback.IsNotNull(nameof(callback));
            __VerifyFingerPrintNumber(fpNumber);

            __handlerObject.Call(
                "modifyFingerprintValidityPeriod",
                __GetTimeForLib(startDate),
                __GetTimeForLib(endDate),
                fpNumber,
                _LockData,
                _LockMac,
                callback
            );
        }

        #endregion Fingerprint

        #endregion Selected lock operations

        #endregion Public methods

        #region Other private members

        private enum ControlAction : byte
        {
            Unlock = 3,
            Lock = 6,
        }

        #endregion Other private members
    }
}
