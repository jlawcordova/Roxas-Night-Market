using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaySimulation.UI
{
    public class EndDayPanel : MonoBehaviour
    {
        public Vector3 EndPosition;
        public float YSpeed;
        public GameObject StallProfitPanelObject;
        private bool endPositionReached = false;

        // Use this for initialization
        void Start()
        {
            StallProfitPanelObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            // Move the end day panel until it reaches the middle of the screen.
            if (!endPositionReached)
            {
                if (transform.position.y > EndPosition.y)
                {
                    transform.position -= new Vector3(0, YSpeed, 0);
                }
                else
                {
                    endPositionReached = true;
                    StallProfitPanelObject.SetActive(true);
                }
            }
        }
    }
}

