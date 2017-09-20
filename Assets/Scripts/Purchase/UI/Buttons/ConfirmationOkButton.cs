using Progress;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Purchase.UI.Buttons
{
    public class ConfirmationOkButton : MonoBehaviour, IPointerClickHandler
    {
        public GameObject CongratsPanelObject;
        public GameObject ConfirmationPanel;

        public void OnPointerClick(PointerEventData eventData)
        {
            ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Remove(BuyConfirmationPanel.instance.RemovableUpgrade);

            // Add upgrade to the stall.
            ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades.Add(BuyConfirmationPanel.instance.Upgrade);
            // Deduct money based on cost.
            ProgressManager.Money -= PurchaseItemPanel.SelectedPurchaseItem.ItemCost;

            CongratsPanelObject.GetComponent<CongratsPanel>().Appear((PurchaseItemPanel.SelectedPurchaseItem).ItemName, (PurchaseItemPanel.SelectedPurchaseItem).ItemDetailSprite);

            ConfirmationPanel.SetActive(false);
        }
    }
}