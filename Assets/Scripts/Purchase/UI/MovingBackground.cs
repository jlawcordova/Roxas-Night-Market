using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purchase.UI
{
    public class MovingBackground : MonoBehaviour
    {
        public float XEndPoint = 0.6666f;
        public float YEndPoint = 1.125f;

        public Vector3 Speed = new Vector3(-0.015f, 0.01f, 0);

        // Update is called once per frame
        void Update()
        {
            // Keep the background moving until it reaches the endpoint.
            if (transform.position.x < XEndPoint && transform.position.y < YEndPoint)
            {
                transform.position += Speed;
            }
            else
            {
                // Reset the background position.
                transform.position = Vector3.zero;
            }

        }
    }
}