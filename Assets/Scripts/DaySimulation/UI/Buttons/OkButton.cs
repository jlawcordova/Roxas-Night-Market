using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Progress;

namespace DaySimulation.UI.Buttons
{
    /// <summary>
    /// Handles the ok button.
    /// </summary>
    public class OkButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the ok button is clicked.
        /// </summary>
        /// <param name="eventData">Pointer click event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            ProfitTracker.instance.Reset();

            SpeedManager.instance.SetToNormalSpeed();

            SceneManager.LoadScene("PreparationScene");
        }
    }
}