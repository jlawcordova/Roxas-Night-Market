using System.Collections.Generic;
using StallSpace.Upgrades;

namespace StallSpace
{
    /// <summary>
    /// Interface for denoting stall space information.
    /// </summary>
    public interface IStallSpaceInformation
    {
        /// <summary>
        /// The type of stall space.
        /// </summary>
        StallSpaceType SpaceType { get; set; }

        /// <summary>
        /// The number of the stall space.
        /// </summary>
        int StallSpaceNumber { get; set; }

        /// <summary>
        /// The amount of stock of the stall.
        /// </summary>
        int StockCount { get; set; }

        /// <summary>
        /// The list of upgrades the stall has.
        /// </summary>
        List<UpgradeData> StallUpgrades { get; set; }
    }
}