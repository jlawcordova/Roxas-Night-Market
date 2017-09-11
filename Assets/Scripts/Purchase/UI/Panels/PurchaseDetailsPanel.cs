using UnityEngine;
using UnityEngine.UI;

namespace Purchase.UI
{
    /// <summary>
    /// Displays the details of a selected item.
    /// </summary>
    public class PurchaseDetailsPanel : MonoBehaviour
    {
        /// <summary>
        /// Index of various children on this panel.
        /// </summary>
        private const int ItemNameTextIndex = 1;
        private const int ItemImageIndex = 2;
        private const int ItemDetailTextIndex = 3;
        private const int BuyButtonIndex = 4;

        /// <summary>
        /// Initialization of the purchase details panel.
        /// </summary>
        void Start()
        {
            PurchaseItemPanel.PointerClicked += PurchaseItem_PointerClicked;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Performed when an item on the Selection panel is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseItem_PointerClicked(object sender, System.EventArgs e)
        {
            ShowDetails(PurchaseItemPanel.SelectedPurchaseItem.ItemName.Replace("\n", " "), PurchaseItemPanel.SelectedPurchaseItem.ItemSprite,
                PurchaseItemPanel.SelectedPurchaseItem.ItemDescription, PurchaseItemPanel.SelectedPurchaseItem.ItemCost);
        }

        /// <summary>
        /// Shows information on the details panel.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="imageSprite">The image of the item.</param>
        /// <param name="itemDetail">The description of the item.</param>
        /// <param name="itemCost">The cost of the item.</param>
        public void ShowDetails(string itemName, Sprite imageSprite, string itemDetail, int itemCost)
        {
            if (this != null)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                transform.GetChild(ItemNameTextIndex).GetComponent<Text>().text = itemName;
                transform.GetChild(ItemImageIndex).GetComponent<Image>().sprite = imageSprite;
                transform.GetChild(ItemDetailTextIndex).GetComponent<Text>().text = itemDetail;
                transform.GetChild(BuyButtonIndex).GetChild(1).GetComponent<Text>().text = itemCost.ToString();
            }
        }
    }
}