using Progress;
using UnityEngine;

namespace StallSpace
{
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
    }
}