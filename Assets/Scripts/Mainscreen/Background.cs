using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mainscreen
{
    public class Background : MonoBehaviour
    {
        public Vector3 FinalPosition;

        public float YSpeed;

        // Use this for initialization
        void Update()
        {
            if (transform.position.y > FinalPosition.y)
            {
                transform.position -= new Vector3(0, YSpeed, 0);
            }
        }
    }
}