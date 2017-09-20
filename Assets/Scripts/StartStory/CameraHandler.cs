using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartStory
{
    public class CameraHandler : MonoBehaviour
    {
        public int CameraXEndpoint;
        public float CameraXSpeed;

        public GameObject[] HiddenOnjects;

        // Use this for initialization
        void Start()
        {
            foreach (GameObject hiddenOnject in HiddenOnjects)
            {
                hiddenOnject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.transform.position.x < CameraXEndpoint)
            {
                gameObject.transform.position += new Vector3(CameraXSpeed, 0, 0);
            }
            else
            {
                foreach (GameObject hiddenOnject in HiddenOnjects)
                {
                    hiddenOnject.SetActive(true);
                }
            }
        }
    }
}