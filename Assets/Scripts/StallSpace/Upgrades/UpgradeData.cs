using System;

namespace StallSpace.Upgrades
{
    [Serializable]
    /// <summary>
    /// Represents information about a stall's upgrade.
    /// </summary>
    public class UpgradeData
    {
        /// <summary>
        /// The number of the upgrade.
        /// </summary>
        public int UpgradeNumber { get; set; }
        /// <summary>
        /// The name of the upgrade.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The slot of the upgrade.
        /// </summary>
        public UpgradeSlot Slot { get; set; }

        /// <summary>
        /// Constructor of the upgrade data.
        /// </summary>
        /// <param name="upgradeNumber">The number of the upgrade.</param>
        /// <param name="slot">The slot of the upgrade.</param>
        public UpgradeData(int upgradeNumber, string name, UpgradeSlot slot)
        {
            this.UpgradeNumber = upgradeNumber;
            this.Name = name;
            this.Slot = slot;
        }
    }
}