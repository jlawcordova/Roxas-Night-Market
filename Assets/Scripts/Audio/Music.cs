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
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}