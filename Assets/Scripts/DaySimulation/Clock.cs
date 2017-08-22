using UnityEngine;
using UnityEngine.SceneManagement;
using DaySimulationUI;

namespace DaySimulation
{
    /// <summary>
    /// Used to determine the current game time.
    /// </summary>
    public class Clock : MonoBehaviour
    {
        #region Clock Properties
        /// <summary>
        /// The amount of delta time per clock minute increment.
        /// </summary>
        public int DeltaTimePerMinuteIncrement;
        public int StartingHour;
        public int StartingMinute;
        public int EndingHour;
        public int EndingMinute;
        #endregion

        #region Current Clock Values
        /// <summary>
        /// The current hour of the clock.
        /// </summary>
        public static int CurrentHour;
        /// <summary>
        /// The current minute of the clock.
        /// </summary>
        public static int CurrentMinute;
        /// <summary>
        /// The current amount of delta time that has elapsed.
        /// </summary>
        private int deltaTimeElapsed = 0;
        #endregion

        /// <summary>
        /// The amount of increment the clock makes every DeltaTimePerMinuteIncrement.
        /// </summary>
        private const int MinuteIncrement = 10;
        /// <summary>
        /// The amount of minutes per hour.
        /// </summary>
        private const int MinutesPerHour = 60;

        void Start()
        {
            CurrentHour = StartingHour;
            CurrentMinute = StartingMinute;
        }

        /// <summary>
        /// Called every deltatime.
        /// </summary>
        void FixedUpdate()
        {
            // Check if the deltatime has elapsed equal to the amount of delta time per clock minute.
            if (deltaTimeElapsed % DeltaTimePerMinuteIncrement == 0)
            {
                CurrentMinute += MinuteIncrement;
                if (CurrentMinute == MinutesPerHour)
                {
                    CurrentMinute = 0;
                    CurrentHour++;
                }
                // Update the UI.
                UIManager.instance.ClockText.text = CurrentHour.ToString() + ":" + CurrentMinute.ToString("00") + "PM";
            }

            if (CurrentHour >= EndingHour && CurrentMinute >= EndingMinute)
            {
                Progress.ProgressManager.SaveProgressToFile();
                SceneManager.LoadScene(0);
            }
            
            deltaTimeElapsed++;
        }
    }
}
