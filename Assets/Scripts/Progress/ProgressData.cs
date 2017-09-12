using System;
using StallSpace;

namespace Progress
{
    /// <summary>
    /// The data stored on the save file.
    /// </summary>
    [Serializable]
    public class ProgressData
    {
        /// <summary>
        /// Information on what is on the stall space.
        /// </summary>
        public StallSpaceInformation[] StallSpaces;
        /// <summary>
        /// Information on the amount of money the player has.
        /// </summary>
        public int Money;
        /// <summary>
        /// The size of the place's area.
        /// </summary>
        public int PlaceSize;
    }
}
