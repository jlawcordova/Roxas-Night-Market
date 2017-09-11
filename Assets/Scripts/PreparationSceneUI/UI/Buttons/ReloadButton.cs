using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PreparationScene.UI.Buttons
{
    public class ReloadButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the sell stall button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            // Reload the scene.
            SceneManager.LoadScene("PreparationScene");
        }
    }
}