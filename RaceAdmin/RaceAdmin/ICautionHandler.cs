namespace RaceAdmin
{
    /// <summary>
    /// Contains methods used by the RaceAdminMain form to communicate with
    /// all caution handlers.
    /// </summary>
    public interface ICautionHandler
    {
        /// <summary>
        /// Called when the current session incident count exceeds the threshold
        /// set by the user.
        /// </summary>
        void CautionThresholdReached();

        /// <summary>
        /// Called to notify the caution handler that a yellow flag has been
        /// thrown in the current session.
        /// </summary>
        void YellowFlagThrown();

        /// <summary>
        /// Called to notify the caution handler than a green flag has been
        /// thrown in the current session. Only called if a yellow flag has 
        /// previously been thrown, ie., not at the start of a race.
        /// </summary>
        void GreenFlagThrown();
    }
}
