using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartStory
{
    public class CameraHandler : MonoBehaviour
    {
        public int CameraXEndpoint;
        public float CameraXSpeed;

        public GameObject Dialogue;

        // Use this for initialization
        void Start()
        {
            Dialogue.SetActive(false);
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
                Dialogue.SetActive(true);
            }
        }
    }
}