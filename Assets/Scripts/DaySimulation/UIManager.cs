using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaySimulation
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
        /// The text displaying the number of customers served.
        /// </summary>
        public Text CustomerServedText;
        /// <summary>
        /// The text displaying the clock's time.
        /// </summary>
        public Text ClockText;
        #endregion

        #region Current UI Values
        /// <summary>
        /// The amount of customers that have been served by all the stalls.
        /// </summary>
        private int customerServed = 0;
        public int CustomerServed
        {
            get
            {
                return customerServed;
            }
            set
            {
                customerServed = value;
                CustomerServedText.text = "Served: " + customerServed;
            }
        }
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