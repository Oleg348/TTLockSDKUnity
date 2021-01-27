namespace OrbitaTech.TTLockUnity
{
    public enum OperationsLogsFilter : byte
    {
        /// <summary>
        /// Only operation that was performed after last log operations retrieving.
        /// </summary>
        New,

        /// <summary>
        /// All operation since lock was initialized.
        /// </summary>
        All
    }
}
