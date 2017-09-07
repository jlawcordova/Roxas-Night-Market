using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using StallSpace;
using Purchase.UI;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the upgrade stall button.
    /// </summary>
    public class UpgradeStallButton : MonoBehaviour, IPointerClickHandler
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
            PurchaseInformation.Type = PurchaseType.UpgradeStall;
            SceneManager.LoadScene("PurchaseScene");
        }
    }
}
