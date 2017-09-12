using UnityEngine;
using UnityEngine.UI;
using Audio;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the music toggle.
    /// </summary>
    public class SoundToggle : MonoBehaviour
    {
        private Toggle soundToggle;

        /// <summary>
        /// Initianlization of the toggle button.
        /// </summary>
        void Start()
        {
            soundToggle = gameObject.GetComponent<Toggle>();
            soundToggle.isOn = PlayerPrefs.GetInt("SoundVolume") == 1 ? true : false;
        }

        /// <summary>
        /// Toggles the music.
        /// </summary>
        public void ToggleSound()
        {
            Sound.instance.ToggleVolume(soundToggle.isOn);
        }
    }
}