using UnityEngine;

namespace Audio
{
    public class Music : MonoBehaviour
    {
        public static Music instance;

        // Use this for initialization
        void Start()
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

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                ToggleVolume(PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false);
            }
            else
            {
                PlayerPrefs.SetInt("MusicVolume", 1);
                ToggleVolume(PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void ToggleVolume(bool on)
        {
            PlayerPrefs.SetInt("MusicVolume", on ? 1 : 0);

            ToggleVolumeNoSave(on);
        }

        public void ToggleVolumeNoSave(bool on)
        {
            if (!on)
            {
                Music.instance.gameObject.GetComponent<AudioSource>().volume = 0;
            }
            else
            {
                Music.instance.gameObject.GetComponent<AudioSource>().volume = 1;
            }
        }
    }
}