using UnityEngine;
using UnityEngine.EventSystems;
using PreparationScene.UI.Panels;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the sell stall button.
    /// </summary>
    public class SellButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the sell stall button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            ClickSelectionManager.instance.gameObject.SetActive(false);
            SellConfirmationPanel.instance.gameObject.SetActive(true);
        }
    }
}