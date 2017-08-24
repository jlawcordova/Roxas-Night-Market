using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace PreparationSceneUI
{
    /// <summary>
    /// The button which begins the day simulation by loading that scene.
    /// </summary>
    public class StartDayButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Load the scene when the button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(2);
        }
    }
}
