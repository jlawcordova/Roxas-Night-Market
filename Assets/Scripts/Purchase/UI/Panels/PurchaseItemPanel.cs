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
        public string ItemName;
        /// <summary>
        /// The sprite of the item.
        /// </summary>
        public Sprite ItemSprite;
        /// <summary>
        /// The sprite of the item icon.
        /// </summary>
        //public Sprite ItemIconSprite;
        /// <summary>
        /// The description of the item.
        /// </summary>
        public string ItemDescription;
        /// <summary>
        /// The cost of the item.
        /// </summary>
        public int ItemCost;
        #endregion

        /// <summary>
        /// Index of various children on this panel.
        /// </summary>
        private const int ItemSpriteIndex = 0;
        private const int ItemNameTextIndex = 1;
        private const int ItemCostTextIndex = 2;

        /// <summary>
        /// Allows listeners to be informed that this item has been clicked.
        /// </summary>
        public static event EventHandler PointerClicked;

        void Start()
        {
            // Set the item's texts.
            //transform.GetChild(ItemSpriteIndex).GetComponent<Image>().sprite = ItemIconSprite;
            transform.GetChild(ItemNameTextIndex).GetComponent<Text>().text = ItemName;
            transform.GetChild(ItemCostTextIndex).GetComponent<Text>().text = ItemCost.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PurchaseItemPanel.SelectedPurchaseItem = this;

            // Inform the listeners that this item has been clicked.
            if (PointerClicked != null)
            {
                PointerClicked(this, new EventArgs());
            }
        }
    }
}