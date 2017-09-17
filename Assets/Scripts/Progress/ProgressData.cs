using System;
using StallSpace;
using System.Collections.Generic;

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
        /// The day in the game.
        /// </summary>
        public int Day;
        /// <summary>
        /// Information on the amount of money the player has.
        /// </summary>
        public int Money;
        /// <summary>
        /// Customer that have been unlocked by the player.
        /// </summary>
        public List<int> CustomersUnlocked;
        /// <summary>
        /// The size of the place's area.
        /// </summary>
        public int PlaceSize;
        /// <summary>
        /// Determines if the game is in tutorial mode.
        /// </summary>
        public bool TutorialMode;
    }
}
