using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Progress;
using StallSpace.Upgrades;

namespace Purchase.UI.Buttons
{
    /// <summary>
    /// Handles the buy button.
    /// </summary>
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        public GameObject CongratsPanelObject;
        public GameObject ConfirmationPanel;

        public GameObject NotEnoughCoinsText;

        /// <summary>
        /// Occurs when the buy button has been clicked.
        /// </summary>
        /// <param name="eventData">Data on the click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (ProgressManager.Money - PurchaseItemPanel.SelectedPurchaseItem.ItemCost >= 0)
            {
                // When buying a stall.
                if (PurchaseInformation.Type == PurchaseType.BuyStall)
                {
                    // Add the purchased stall into the stallspace.
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].SpaceType = ((StallPurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).Type;
                    // TODO Refactor this. Make the fountain script more loosly coupled from this script.
                    if (((StallPurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).Type == StallSpace.StallSpaceType.Fountain)
                    {
                        // Set a fountain with a stock count of 1 which will never be sold.
                        ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StockCount = 1;
                    }
                    // Deduct money based on item cost.
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;
                }
                // When buying an upgrade.
                else if (PurchaseInformation.Type == PurchaseType.UpgradeStall) 
                {
                    #region Buying Upgrade
                    // Get the upgrade details of the purchased item.
                    int upgradeNumber = ((UpgradePurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).UpgradeNumber;
                    string name = (PurchaseItemPanel.SelectedPurchaseItem).ItemName;
                    UpgradeSlot slot = ((UpgradePurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).Slot;

                    // Create a new list if the stall upgrade list is null.
                    if (ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades == null)
                    {
                        ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades = new List<UpgradeData>();
                    }
                    else
                    {
                        // Replace upgrade in the same upgrade slot.
                        foreach (UpgradeData upgrade in ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades)
                        {
                            // TODO Inform the player that a stall is about to be replaced.
                            if (upgrade.Slot == slot)
                            {
                                BuyConfirmationPanel.instance.RemovableUpgrade = upgrade;
                                BuyConfirmationPanel.instance.Upgrade = new UpgradeData(upgradeNumber, name, slot);
                                ConfirmationPanel.SetActive(true);
                                return;
                            }
                        }
                    }

                    // Add upgrade to the stall.
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Add(new UpgradeData(upgradeNumber, name, slot));
                    // Deduct money based on cost.
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;
                    #endregion
                }

                CongratsPanelObject.GetComponent<CongratsPanel>().Appear((PurchaseItemPanel.SelectedPurchaseItem).ItemName, (PurchaseItemPanel.SelectedPurchaseItem).ItemDetailSprite);
            }
            else
            {
                Instantiate(NotEnoughCoinsText, gameObject.transform.parent.parent);
            }
        }
    }
}
