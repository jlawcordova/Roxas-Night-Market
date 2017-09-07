using System;
using System.Collections.Generic;

namespace StallSpace
{
    /// <summary>
    /// Information on the stall space.
    /// </summary>
    [Serializable]
    public class StallSpaceInformation : IStallSpaceInformation
    {
        public StallSpaceType SpaceType { get; set; }
        public int StallSpaceNumber { get; set; }
        public int StockCount { get; set; }

        public List<int> StallUpgrades { get; set; }
    }
}