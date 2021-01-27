namespace OrbitaTech.TTLockUnity
{
    public class PassageModeConfig
    {
        public PassageModeType PassageType { get; set; }

        /// <summary>
        /// Minutes passed starting from 00:00.
        /// </summary>
        public int StartTime { get; set; }

        /// <summary>
        /// Minutes passed starting from 00:00.
        /// </summary>
        public int EndTime { get; set; }

        /// <summary>
        /// - For <see cref="PassageType"/> == <see cref="PassageModeType.Weekly"/> array contains numbers of {1,..,7}; (1 is Monday).
        /// <code></code>
        /// - For <see cref="PassageType"/> == <see cref="PassageModeType.Monthly"/> array contains numbers of {1,..,12};
        /// </summary>
        public byte[] AccessiblePeriods { get; set; }
    }
}
