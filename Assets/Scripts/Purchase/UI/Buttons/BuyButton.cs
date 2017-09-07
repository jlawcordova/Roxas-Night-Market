using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Progress;

namespace Purchase.UI.Buttons
{
    /// <summary>
    /// Handles the buy button.
    /// </summary>
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the buy button has been clicked.
        /// </summary>
        /// <param name="eventData">Data on the click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (ProgressManager.Money - PurchaseItemPanel.SelectedPurchaseItem.ItemCost >= 0)
            {
                if (PurchaseInformation.Type == PurchaseType.BuyStall)
                {
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].SpaceType = ((StallPurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).Type;
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;

                    SceneManager.LoadScene(1);
                }
                else if (PurchaseInformation.Type == PurchaseType.UpgradeStall) 
                {
                    if (ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades == null)
                    {
                        ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades = new List<int>();
                    }
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Add(((UpgradePurchaseItemPanel)PurchaseItemPanel.SelectedPurchaseItem).UpgradeNumber);
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;

                    SceneManager.LoadScene(1);
                }
                
            }
        }
    }
}
