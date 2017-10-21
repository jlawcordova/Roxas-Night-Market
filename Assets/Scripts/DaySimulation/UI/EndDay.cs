using UnityEngine;

namespace DaySimulation.UI
{
    public class EndDay : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            // Hide the end day panel at the start of the simulation.
            gameObject.SetActive(false);
        }
    }

}