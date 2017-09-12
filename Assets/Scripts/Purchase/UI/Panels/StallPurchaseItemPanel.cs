using UnityEngine.UI;
using StallSpace;

namespace Purchase.UI
{
    /// <summary>
    /// Represents a stall which can be purchased.
    /// </summary>
    public class StallPurchaseItemPanel : PurchaseItemPanel
    {
        /// <summary>
        /// The stall space type of the purchasable item.
        /// </summary>
        public StallSpaceType Type;

        /// <summary>
        /// Initialization of the upgrade purchase item panel.
        /// </summary>
        void Start()
        {
            // Set the icon of this item.
            transform.GetChild(ItemSpriteIndex).GetComponent<Image>().sprite = ItemIconSprite;
            // Set the name of this item.
            transform.GetChild(ItemNameTextIndex).GetComponent<Text>().text = ItemName;
            // Set the cost of this item.
            transform.GetChild(ItemCostTextIndex).GetComponent<Text>().text = ItemCost.ToString();
        }
    }
}