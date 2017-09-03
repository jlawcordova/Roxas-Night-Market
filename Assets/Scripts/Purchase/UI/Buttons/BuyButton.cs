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
                    // TODO Stall space type must vary depending on selected purchase.
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].SpaceType = StallSpace.StallSpaceType.Stall;
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;

                    SceneManager.LoadScene(1);
                }
                else if (PurchaseInformation.Type == PurchaseType.UpgradeKwekkwekStall) 
                {
                    // TODO Upgrade must vary depending on selected purchase.
                    ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades = new List<int>() { 0 };
                    ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;

                    SceneManager.LoadScene(1);
                }
                
            }
        }
    }
}
