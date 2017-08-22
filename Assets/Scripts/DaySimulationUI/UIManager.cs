using UnityEngine;
using UnityEngine.UI;

namespace DaySimulationUI
{
    /// <summary>
    /// Handles the UI on the game screen.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        ///  The UI manager singleton instance.
        /// </summary>
        public static UIManager instance = null;

        #region UI Objects to be Mananged
        /// <summary>
        /// The speed button on the UI.
        /// </summary>
        public Button SpeedButton;
        /// <summary>
        /// The text displaying the clock's time.
        /// </summary>
        public Text ClockText;
        #endregion

        /// <summary>
        /// During initialization.
        /// </summary>
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            SpeedButton.GetComponent<Button>().onClick.AddListener(OnClickSpeedButton);
        }

        /// <summary>
        /// Called when the speed button is clicked.
        /// </summary>
        void OnClickSpeedButton()
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