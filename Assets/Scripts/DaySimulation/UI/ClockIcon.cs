using UnityEngine;
using UnityEngine.UI;

namespace DaySimulation.UI
{
    /// <summary>
    /// Handles the clock icon.
    /// </summary>
    public class ClockIcon : MonoBehaviour
    {
        /// <summary>
        /// The icon when it is daytime.
        /// </summary>
        public Sprite DaySprite;
        /// <summary>
        /// The icon when it is nighttime.
        /// </summary>
        public Sprite NightSprite;

        /// <summary>
        /// The hour when it is nighttime.
        /// </summary>
        public int NightHour;
        /// <summary>
        /// The minute when it is nighttime.
        /// </summary>
        public int NightMinute;

        // Initialization of the clock icon.
        void Start()
        {
            gameObject.GetComponent<Image>().sprite = DaySprite;
        }

        // Update is called once per frame
        void Update()
        {
            // Check if night time. Change icon accordingly.
            if (Clock.CurrentHour == NightHour && Clock.CurrentMinute == NightMinute)
            {
                gameObject.GetComponent<Image>().sprite = NightSprite;
            }
        }
    }
}