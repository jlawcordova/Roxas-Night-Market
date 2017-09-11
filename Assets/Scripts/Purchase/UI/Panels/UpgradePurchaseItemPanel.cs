﻿using StallSpace.Upgrades;

namespace Purchase.UI
{
    /// <summary>
    /// Represents an upgrade which can be purchased for a stall.
    /// </summary>
    public class UpgradePurchaseItemPanel : PurchaseItemPanel
    {
        /// <summary>
        /// The number of the upgrade.
        /// </summary>
        public int UpgradeNumber;

        /// <summary>
        /// The slot of the upgrade.
        /// </summary>
        public UpgradeSlot Slot;
    }
}