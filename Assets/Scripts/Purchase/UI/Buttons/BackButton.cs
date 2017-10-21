using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Purchase.UI.Buttons
{
    /// <summary>
    /// Handles the back button.
    /// </summary>
    public class BackButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the back button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene("PreparationScene");
        }
    }
}