using System.Collections.Generic;
using UnityEngine;
using StallSpace.Upgrades;

namespace StallSpace
{
    /// <summary>
    ///  Represents a stall space on the scene.
    ///  A stall space can either be a stall or an empty stall.
    /// </summary>
    public class StallSpace : MonoBehaviour, IStallSpaceInformation
    {
        /// <summary>
        /// The stall space type. Always Stall type.
        /// </summary>
        public StallSpaceType SpaceType { get; set; }

        /// <summary>
        /// The stall space number of the stall.
        /// </summary>
        public int StallSpaceNumber { get; set; }

        /// <summary>
        /// The amount of stock on the stall space.
        /// </summary>
        public int StockCount { get; set; }

        /// <summary>
        /// The upgrades made on the stall space.
        /// </summary>
        public List<UpgradeData> StallUpgrades { get; set; }
    }
}