using UnityEngine;
using UnityEngine.UI;

namespace DaySimulation.UI
{
    /// <summary>
    /// Handles the UI on the game screen.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        ///  The UI manager singleton instance.
        /// </summary>
        [HideInInspector]
        public static UIManager instance = null;

        #region UI Objects to be Mananged
        /// <summary>
        /// The text displaying the clock's time.
        /// </summary>
        public Text ClockText;
        #endregion

        /// <summary>
        /// Awakening of the UI manager.
        /// </summary>
        void Awake()
        {
            // Only one UI manager can exist.
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Initialization of the UI manager.
        /// </summary>
        void Start()
        {
            // Make the UI manager informed when the clock is updated.
            Clock.instance.ClockUpdated += UIManager_ClockUpdated;
        }

        /// <summary>
        /// Occurs when the clock has been updated.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Arguments of the event.</param>
        private void UIManager_ClockUpdated(object sender, System.EventArgs e)
        {
            ClockText.text = Clock.CurrentHour.ToString() + ":" + Clock.CurrentMinute.ToString("00") + "PM";
        }
    }
}