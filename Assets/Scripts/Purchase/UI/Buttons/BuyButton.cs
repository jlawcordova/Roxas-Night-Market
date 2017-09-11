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
                    // Deduct money based on item cost.
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;
                }
                // When buying an upgrade.
                else if (PurchaseInformation.Type == PurchaseType.UpgradeStall) 
                {
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
                                ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Remove(upgrade);
                                break;
                            }
                        }
                    }

                    // Add upgrade to the stall.
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Add(new UpgradeData(upgradeNumber, name, slot));

                    // Deduct money based on cost.
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;
                }

                CongratsPanelObject.GetComponent<CongratsPanel>().Appear((PurchaseItemPanel.SelectedPurchaseItem).ItemName, (PurchaseItemPanel.SelectedPurchaseItem).ItemSprite);
            }
        }
    }
}
