using UnityEngine;
using UnityEngine.EventSystems;

namespace DaySimulation.UI.Buttons
{
    /// <summary>
    /// Handles the speed button.
    /// </summary>
    public class SpeedButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            // Check if the game is sped up already, if so, set it back to normal.
            // Otherwise speed it up.   
            if (Time.timeScale >= SpeedManager.instance.SpeedUpScale)
            {
                SpeedManager.instance.SetToNormalSpeed();
            }
            else
            {
                SpeedManager.instance.SpeedUp();
            }
        }
    }
}

