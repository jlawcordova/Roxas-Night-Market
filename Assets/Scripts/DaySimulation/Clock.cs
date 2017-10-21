using System;
using UnityEngine;
using Progress;

namespace DaySimulation
{
    /// <summary>
    /// Used to determine the current game time.
    /// </summary>
    public class Clock : MonoBehaviour
    {
        /// <summary>
        /// Clock singleton instance.
        /// </summary>
        [HideInInspector]
        public static Clock instance;

        /// <summary>
        /// The panel to be displayed when the day has ended.
        /// </summary>
        public GameObject EndDay;

        /// <summary>
        /// The button to be hidden when the day has ended.
        /// </summary>
        public GameObject SpeedButton;

        #region Clock Properties
        /// <summary>
        /// The amount of delta time per clock minute increment.
        /// </summary>
        public int DeltaTimePerMinuteIncrement;

        /// <summary>
        /// The starting hour of the simulation.
        /// </summary>
        public int StartingHour;
        /// <summary>
        /// The starting minute of the simulation.
        /// </summary>
        public int StartingMinute;

        /// <summary>
        /// The hour at which simulation will end.
        /// </summary>
        public int EndingHour;
        /// <summary>
        /// The minute at which simulation will end.
        /// </summary>
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

        /// <summary>
        /// Allows listeners to be informed that the clock has been updated.
        /// </summary>
        public event EventHandler ClockUpdated;

        private bool DayIncremented = false;

        /// <summary>
        /// Awakening of the clock.
        /// </summary>
        void Awake()
        {
            // Only one clock instance is allowed.
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
        /// Initialization of the clock.
        /// </summary>
        void Start()
        {
            // Set the starting hour and minute.
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

                // Inform the listeners that the clock has been updated.
                if (ClockUpdated != null)
                {
                    ClockUpdated(this, new EventArgs());
                }
            }

            // End the simulation when the end hour and minute has been reached.
            if (CurrentHour >= EndingHour && CurrentMinute >= EndingMinute)
            {
                SpeedManager.instance.Pause();
                if (!DayIncremented)
                {
                    ProgressManager.Day++;
                    DayIncremented = true;

                    // Unlock a customer if possible.
                    int unlockedCustomerNumber;
                    ProgressManager.CheckCustomerUnlock(out unlockedCustomerNumber);
                }
                ProgressManager.SaveProgressToFile();

                // Display the end day panel.
                EndDay.SetActive(true);

                // Hide the speed button.
                SpeedButton.SetActive(false);
            }
            
            deltaTimeElapsed++;
        }
    }
}
