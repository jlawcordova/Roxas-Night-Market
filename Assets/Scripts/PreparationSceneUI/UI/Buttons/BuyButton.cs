using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using StallSpace;
using Purchase.UI;
using Progress;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the buy button when buying a stall for an empty space.
    /// </summary>
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the button is clicked.
        /// </summary>
        /// <param name="eventData">The data on the click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            IStallSpaceInformation selectedStallSpace = UIManager.instance.SelectedStallSpace.GetComponent<IStallSpaceInformation>();

            // Inform the next scene on what stallspace will be affected by the purchase.
            PurchaseInformation.StallToAffect = selectedStallSpace.StallSpaceNumber;
            PurchaseInformation.Type = PurchaseType.BuyStall;

            if (ProgressManager.TutorialMode)
            {
                SceneManager.LoadScene("TutorialPurchaseScene");
            }
            else
            {
                SceneManager.LoadScene("PurchaseScene");
            }
        }
    }
}