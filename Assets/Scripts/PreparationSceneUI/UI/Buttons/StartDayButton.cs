using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Audio;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// The button which begins the day simulation by loading that scene.
    /// </summary>
    public class StartDayButton : MonoBehaviour, IPointerClickHandler
    {
        public GameObject FadeToSceneObject;

        /// <summary>
        /// Load the scene when the button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            FadeToSceneObject.SetActive(true);
            Music.instance.Destroy();
        }
    }
}
