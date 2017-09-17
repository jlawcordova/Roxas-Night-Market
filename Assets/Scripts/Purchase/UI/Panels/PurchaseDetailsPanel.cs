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
        private const int AlreadyBoughtIndex = 5;
        private const int PlacementIndex = 6;
        private const int PlacementLabelIndex = 7;

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
            ShowDetails(PurchaseItemPanel.SelectedPurchaseItem.ItemName.Replace("\n", " "), PurchaseItemPanel.SelectedPurchaseItem.ItemDetailSprite,
                PurchaseItemPanel.SelectedPurchaseItem.ItemDescription, PurchaseItemPanel.SelectedPurchaseItem.ItemCost, PurchaseItemPanel.SelectedPurchaseItem.IsPurchased);
        }

        /// <summary>
        /// Shows information on the details panel.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <param name="imageSprite">The image of the item.</param>
        /// <param name="itemDetail">The description of the item.</param>
        /// <param name="itemCost">The cost of the item.</param>
        public void ShowDetails(string itemName, Sprite imageSprite, string itemDetail, int itemCost, bool isPurchased)
        {
            if (this != null)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                // Display item details.
                transform.GetChild(ItemNameTextIndex).GetComponent<Text>().text = itemName;
                transform.GetChild(ItemImageIndex).GetComponent<Image>().sprite = imageSprite;
                transform.GetChild(ItemDetailTextIndex).GetComponent<Text>().text = itemDetail;

                // Display buy button only if the item has not been purchased yet.
                if (isPurchased)
                {
                    transform.GetChild(BuyButtonIndex).gameObject.SetActive(false);
                    transform.GetChild(AlreadyBoughtIndex).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(AlreadyBoughtIndex).gameObject.SetActive(false);
                    transform.GetChild(BuyButtonIndex).GetChild(1).GetComponent<Text>().text = itemCost.ToString();
                }

                // Determine if slot should be shown (for upgrades).
                switch (PurchaseInformation.Type)
                {
                    case PurchaseType.BuyStall:
                        transform.GetChild(PlacementIndex).gameObject.SetActive(false);
                        transform.GetChild(PlacementLabelIndex).gameObject.SetActive(false);

                        break;
                    case PurchaseType.UpgradeStall:
                        // Set the text depending on the slot.
                        transform.GetChild(PlacementIndex).gameObject.SetActive(true);
                        transform.GetChild(PlacementLabelIndex).gameObject.SetActive(true);
                        
                        switch (((UpgradePurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).Slot)
                        {
                            case StallSpace.Upgrades.UpgradeSlot.Back:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Back";

                                break;
                            case StallSpace.Upgrades.UpgradeSlot.Front:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Front";

                                break;
                            case StallSpace.Upgrades.UpgradeSlot.Left:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Left";

                                break;
                            case StallSpace.Upgrades.UpgradeSlot.Right:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Right";

                                break;
                            case StallSpace.Upgrades.UpgradeSlot.Street:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Street";

                                break;
                            case StallSpace.Upgrades.UpgradeSlot.Top:
                                transform.GetChild(PlacementIndex).GetComponent<Text>().text = "Top"    ;

                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}