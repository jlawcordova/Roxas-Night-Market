using UnityEngine;
using UnityEngine.EventSystems;
using PreparationScene.UI.Panels;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the exit game button.
    /// </summary>
    public class ExitGameButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the exit game button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}
