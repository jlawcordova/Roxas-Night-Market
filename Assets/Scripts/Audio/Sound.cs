using UnityEngine;

namespace Audio
{
    /// <summary>
    /// Handles the sounds that play in the game.
    /// </summary>
    public class Sound : MonoBehaviour
    {
        public static Sound instance;
        public bool IsOn;

        /// <summary>
        /// Awakening of the sound object.
        /// </summary>
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            if (PlayerPrefs.HasKey("SoundVolume"))
            {
                ToggleVolume(PlayerPrefs.GetInt("SoundVolume") == 1 ? true : false);
            }
            else
            {
                PlayerPrefs.SetInt("SoundVolume", 1);
                ToggleVolume(PlayerPrefs.GetInt("SoundVolume") == 1 ? true : false);
            }
        }

        /// <summary>
        /// Toggles the volume of the sound.
        /// </summary>
        /// <param name="isOn">The status of the volume of the sound.</param>
        public void ToggleVolume(bool isOn)
        {
            PlayerPrefs.SetInt("SoundVolume", isOn ? 1 : 0);

            this.IsOn = isOn;
        }

        /// <summary>
        /// Sets the sound of an audio source.
        /// </summary>
        /// <param name="source">The audio source to be set.</param>
        public static void SetSound(AudioSource source, float volume)
        {
            source.volume = Sound.instance.IsOn ? volume : 0;
        }
    }
}