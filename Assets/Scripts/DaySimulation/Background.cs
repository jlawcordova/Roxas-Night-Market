using UnityEngine;

namespace DaySimulation
{
    public class Background : MonoBehaviour
    {
        public int NightHour;
        public int NightMinute;

        // Update is called once per frame
        void Update()
        {
            if (Clock.CurrentHour == NightHour && Clock.CurrentMinute == NightMinute)
            {
                gameObject.GetComponent<Animator>().SetTrigger("IsNight");
            }
        }
    }
}