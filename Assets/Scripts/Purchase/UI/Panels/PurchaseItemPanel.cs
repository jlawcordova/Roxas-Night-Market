using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Purchase.UI
{
    /// <summary>
    /// Represents an item on the purchase selection grid.
    /// </summary>
    public class PurchaseItemPanel : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// The selected item on the selection grid.
        /// </summary>
        [HideInInspector]
        public static PurchaseItemPanel SelectedPurchaseItem;

        #region Purchase Item Properties
        /// <summary>
        /// The name of the item.
        /// </summary>
        [TextArea]
        public string ItemName;
        /// <summary>
        /// The sprite of the item.
        /// </summary>
        public Sprite ItemDetailSprite;
        /// <summary>
        /// The sprite of the item icon.
        /// </summary>
        public Sprite ItemIconSprite;
        /// <summary>
        /// The description of the item.
        /// </summary>
        [TextArea]
        public string ItemDescription;
        /// <summary>
        /// The cost of the item.
        /// </summary>
        public int ItemCost;

        /// <summary>
        /// Determines if the object has already been purchased.
        /// </summary>
        [HideInInspector]
        public bool IsPurchased = false;
        #endregion

        /// <summary>
        /// Index of various children on the item panel.
        /// </summary>
        public const int ItemSpriteIndex = 0;
        public const int ItemNameTextIndex = 1;
        public const int ItemCostTextIndex = 2;

        /// <summary>
        /// Allows listeners to be informed that this item has been clicked.
        /// </summary>
        public static event EventHandler PointerClicked;

        /// <summary>
        /// Occurs when clicking the purchase item.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            // Make this the selected item.
            PurchaseItemPanel.SelectedPurchaseItem = this;

            // Inform the listeners that this item has been clicked.
            if (PointerClicked != null)
            {
                PointerClicked(this, new EventArgs());
            }
        }
    }
}