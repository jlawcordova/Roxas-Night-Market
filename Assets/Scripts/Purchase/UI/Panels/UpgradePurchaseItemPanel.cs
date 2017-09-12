using UnityEngine.UI;
using StallSpace.Upgrades;

namespace Purchase.UI
{
    /// <summary>
    /// Represents an upgrade which can be purchased for a stall.
    /// </summary>
    public class UpgradePurchaseItemPanel : PurchaseItemPanel
    {
        /// <summary>
        /// Index of various children on this panel.
        /// </summary>
        public const int ItemPanel = 0;
        public const int FilterPanelIndex = 1;

        /// <summary>
        /// The number of the upgrade.
        /// </summary>
        public int UpgradeNumber;

        /// <summary>
        /// The slot of the upgrade.
        /// </summary>
        public UpgradeSlot Slot;

        /// <summary>
        /// Initialization of the upgrade purchase item panel.
        /// </summary>
        void Start()
        {
            // Set the icon of this item.
            transform.GetChild(ItemPanel).transform.GetChild(ItemSpriteIndex).GetComponent<Image>().sprite = ItemIconSprite;
            // Set the name of this item.
            transform.GetChild(ItemPanel).transform.GetChild(ItemNameTextIndex).GetComponent<Text>().text = ItemName;
            // Set the cost of this item.
            transform.GetChild(ItemPanel).transform.GetChild(ItemCostTextIndex).GetComponent<Text>().text = ItemCost.ToString();
        }
    }
}