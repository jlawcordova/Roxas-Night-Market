using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparationScene.UI.Texts
{
    public class WarningText : MonoBehaviour
    {
        public float YOffsetToDestroy = 0.5f;
        public float YSpeed = 0.005f;

        private float totalMove = 0;

        // Update is called once per frame
        void Update()
        {
            if (totalMove < YOffsetToDestroy)
            {
                transform.position += new Vector3(0, YSpeed, 0);
                totalMove += YSpeed;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
