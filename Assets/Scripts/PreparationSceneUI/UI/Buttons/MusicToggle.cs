using UnityEngine;
using UnityEngine.UI;
using Audio;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the music toggle.
    /// </summary>
    public class MusicToggle : MonoBehaviour
    {
        private Toggle musicToggle;

        /// <summary>
        /// Initianlization of the toggle button.
        /// </summary>
        void Start()
        {
            musicToggle = gameObject.GetComponent<Toggle>();
            musicToggle.isOn = PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false;
        }

        /// <summary>
        /// Toggles the music.
        /// </summary>
        public void ToggleMusic()
        {
            Music.instance.ToggleVolume(musicToggle.isOn);
        }
    }
}