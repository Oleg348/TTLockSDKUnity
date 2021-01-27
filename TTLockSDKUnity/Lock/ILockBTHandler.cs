using System;

using UnityEngine;

namespace OrbitaTech.TTLockUnity
{
    /// <summary>
    /// Bluetooth lock handler.
    /// </summary>
    public interface ILockBTHandler
    {
        #region Common methods

        /// <summary>
        /// Check if BT is enabled.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        bool IsBTEnabled(AndroidJavaObject context);

        /// <summary>
        /// Request BT enable.
        /// </summary>
        /// <param name="activity"></param>
        /// <exception cref="ArgumentNullException"/>
        void RequestBTEnable(AndroidJavaObject activity);

        /// <summary>
        /// Prepare BT service.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"/>
        void PrepareBTService(AndroidJavaObject context);

        /// <summary>
        /// Stop BT service.
        /// </summary>
        void StopBTService();

        /// <summary>
        /// Start scanning for locks.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        void StartScanLocks(ScanLockCallback callback);

        /// <summary>
        /// Stop scanning for locks.
        /// </summary>
        void StopScanLocks();

        /// <summary>
        /// Initialize lock.
        /// </summary>
        /// <param name="lockDevice"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lockDevice"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        void InitializeLock(BTDeviceInfo lockDevice, InitLockCallback callback);

        #endregion Common methods

        /// <summary>
        /// Lock operate.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException">
        /// <see cref="LockInfo.LockData"/> is null
        /// </exception>
        LockInfo LockToOperate { get; set; }

        #region Lock operations

        /// <summary>
        /// Reset lock EKey.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ResetLockEKey(ResetEKeyCallback callback);

        /// <summary>
        /// Deinitialize lock.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ResetLock(ResetLockCallback callback);

        /// <summary>
        /// Open lock.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void OpenLock(ControlLockCallback callback);

        /// <summary>
        /// Close lock.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void CloseLock(ControlLockCallback callback);

        #region Configuration

        /// <summary>
        /// Get lock mute state.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockMuteModeState(GetLockMuteModeStateCallback callback);

        /// <summary>
        /// Set lock mute state.
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void SetLockMuteModeState(bool enable, SetLockMuteModeStateCallback callback);

        /// <summary>
        /// Get lock remote unlocking ability.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockRemoteUnlockingState(GetRemoteUnlockingStateCallback callback);

        /// <summary>
        /// Set lock remote unlocking ability.
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void SetLockRemoteUnlockingState(bool enable, SetRemoteUnlockingStateCallback callback);

        /// <summary>
        /// Get lock date and time.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockTime(GetLockTimeCallback callback);

        /// <summary>
        /// Set new lock date and time.
        /// </summary>
        /// <param name="newTime"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void SetLockTime(DateTime newTime, SetLockTimeCallback callback);

        /// <summary>
        /// Get lock battery level.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockBatteryLevel(GetBatteryLevelCallback callback);

        /// <summary>
        /// Set lock auto-lock period.
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException">
        /// <paramref name="seconds"/> is negative
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void SetLockAutolockPeriod(int seconds, SetAutoLockingPeriodCallback callback);

        #endregion Configuration

        #region Pass code

        /// <summary>
        /// Create new keyboard pass code.
        /// </summary>
        /// <param name="passcode">6-9 digits string.</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="passcode"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcode"/> is empty or whitespace or contains non digits symbols.
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void CreateLockCustomPasscode(string passcode, DateTime? startDate, DateTime? endDate, CreateCustomPasscodeCallback callback);

        /// <summary>
        /// Modify existing keyboard pass code.
        /// </summary>
        /// <param name="originalPassocde"></param>
        /// <param name="newPasscode">null or <see cref="string.Empty"/> to not change the original pass code.</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="originalPassocde"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcode"/> is empty or whitespace or contains non digits symbols.
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ModifyLockPasscode(string originalPassocde, string newPasscode, DateTime? startDate, DateTime? endDate, ModifyPasscodeCallback callback);

        /// <summary>
        /// Delete existing keyboard pass code.
        /// </summary>
        /// <param name="passcode"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="passcode"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcode"/> is empty or whitespace or contains non digits symbols.
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void DeleteLockPasscode(string passcode, DeletePasscodeCallback callback);

        /// <summary>
        /// Make all the lock pass codes invalid.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ResetLockAllPasscodes(ResetAllPasscodesCallback callback);

        /// <summary>
        /// Get all the pass codes of lock.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockAllValidPasscodes(GetAllValidPasscodesCallback callback);

        /// <summary>
        /// Modify admin pass code.
        /// </summary>
        /// <param name="newPasscode"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="passcode"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcode"/> is empty or whitespace or contains non digits symbols.
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ModifyLockAdminPasscode(string newPasscode, ModifyAdminPasscodeCallback callback);

        #endregion Pass code

        #region Passage mode

        /// <summary>
        /// Get lock passage mode config.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetLockPassageMode(GetLockPassageStateCallback callback);

        /// <summary>
        /// Set passage mode config.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="config"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">Invalid config params</exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void SetLockPassageMode(PassageModeConfig config, SetLockPassageStateCallback callback);

        /// <summary>
        /// Delete passage mode config.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="config"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">Invalid config params</exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void DeleteLockPassageMode(PassageModeConfig config, DeletePassageModeCallback callback);

        /// <summary>
        /// Clear passage mode.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ClearLockPassageMode(ClearPassageModeCallback callback);

        #endregion Passage mode

        /// <summary>
        /// Get lock logs.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException">Invalid <paramref name="filter"/></exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetOperationLogs(OperationsLogsFilter filter, GetOperationsLogsCallback callback);

        #region Fingerprint

        /// <summary>
        /// Add fingerprint.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void AddLockFingerprint(DateTime? startDate, DateTime? endDate, AddFingerprintCallback callback);

        /// <summary>
        /// Get all fingerprints.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetAllLockValidFingerprints(GetAllValidFingerprintsCallback callback);

        /// <summary>
        /// Make fingerprint invalid.
        /// </summary>
        /// <param name="fpNumber"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="fpNumber"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="fpNumber"/> is empty or contains non digits symbols
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void DeleteLockFingerprint(string fpNumber, DeleteFingerprintCallback callback);

        /// <summary>
        /// Clear all the lock fingerprints.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ClearAllLockFingerprints(ClearFingerprintsCallback callback);

        /// <summary>
        /// Modify fingerprint period.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="fpNumber"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="fpNumber"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="fpNumber"/> is empty or contains non digits symbols
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ModifyLockFingerprintPeriod(DateTime? startDate, DateTime? endDate, string fpNumber, ModifyFingerprintPeriodCallback callback);

        #endregion Fingerprint

        #region IC Card

        /// <summary>
        /// Add IC card.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void AddLockICCard(DateTime? startDate, DateTime? endDate, AddICCardCallback callback);

        /// <summary>
        /// Modify IC card period.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cardNumber"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="cardNumber"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="cardNumber"/> is empty or contains non digits symbols
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ModifyLockICCardPeriod(DateTime? startDate, DateTime? endDate, string cardNumber, ModifyICCardPeriodCallback callback);

        /// <summary>
        /// Get all lock IC cards.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void GetAllLockValidICCards(GetAllValidICCardsCallback callback);

        /// <summary>
        /// Make IC card invalid.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="cardNumber"/> is null
        /// -or-
        /// <paramref name="callback"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="cardNumber"/> is empty or contains non digits symbols
        /// </exception>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void DeleteLockICCard(string cardNumber, DeleteICCardCallback callback);

        /// <summary>
        /// Clear all the fingerprints.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="LockToOperate"/> is null.</exception>
        void ClearAllLockICCards(ClearAllICCardsCallback callback);

        #endregion IC Card

        #endregion Lock operations
    }
}
