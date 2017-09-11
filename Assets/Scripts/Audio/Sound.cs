using UnityEngine;

namespace Audio
{
    public class Sound : MonoBehaviour
    {
        public static Sound instance;
        private AudioSource source;

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

            source = gameObject.GetComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound(AudioClip clip)
        {
            source.clip = clip;

            source.Play();
        }
    }
}