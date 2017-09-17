using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DaySimulation.UI.Buttons
{
    /// <summary>
    /// Handles the speed button.
    /// </summary>
    public class SpeedButton : MonoBehaviour, IPointerClickHandler
    {
        public Sprite SpeedUp;
        public Sprite NormalSpeed;

        [TextArea]
        public string SpeedUpText;
        [TextArea]
        public string NormalSpeedText;

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
                gameObject.GetComponent<Image>().sprite = SpeedUp;
                transform.GetChild(0).gameObject.GetComponent<Text>().text = SpeedUpText;
                SpeedManager.instance.SetToNormalSpeed();
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = NormalSpeed;
                transform.GetChild(0).gameObject.GetComponent<Text>().text = NormalSpeedText;
                SpeedManager.instance.SpeedUp();
            }
        }
    }
}

