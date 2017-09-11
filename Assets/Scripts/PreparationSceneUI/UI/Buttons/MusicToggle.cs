using UnityEngine;
using UnityEngine.UI;
using Audio;

namespace PreparationScene.UI.Buttons
{
    public class MusicToggle : MonoBehaviour
    {
        private Toggle musicToggle;

        // Use this for initialization
        void Start()
        {
            musicToggle = gameObject.GetComponent<Toggle>();
            musicToggle.isOn = PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false;
        }

        public void ToggleMusic()
        {
            Music.instance.ToggleVolume(musicToggle.isOn);
        }
    }
}