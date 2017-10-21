using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndingScene
{
    public class GameOver : MonoBehaviour
    {
        public float YSpeed;
        public float YEndPoint;

        public GameObject[] HiddenObjects;

        // Use this for initialization
        void Start()
        {
            if (Music.instance != null)
            {
                Destroy(Music.instance.gameObject);
            }

            foreach (GameObject hiddenObject in HiddenObjects)
            {
                hiddenObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > YEndPoint)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + YSpeed, transform.position.z);
            }
            else
            {
                foreach (GameObject hiddenObject in HiddenObjects)
                {
                    hiddenObject.SetActive(true);
                }
            }
        }
    }
}