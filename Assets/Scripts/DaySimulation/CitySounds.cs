using UnityEngine;
using Audio;

namespace DaySimulation
{
    public class CitySounds : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            // Set the soound of this game object based on the settings.
            Sound.SetSound(gameObject.GetComponent<AudioSource>(), 0.35f);
        }
    }

}