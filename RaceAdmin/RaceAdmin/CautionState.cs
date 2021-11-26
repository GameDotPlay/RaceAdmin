namespace RaceAdmin
{
    /// <summary>
    /// Tracks the current state of the caution handling system.
    /// </summary>
	public enum CautionState
	{
        /// <summary>
        /// Initial state.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the application incident threshold for a caution 
        /// has been reached.
        /// </summary>
        ThresholdReached,

        /// <summary>
        /// Indicates that a full course yellow has been initiated within
        /// iRacing.
        /// </summary>
        YellowFlagDeployed
    }
}