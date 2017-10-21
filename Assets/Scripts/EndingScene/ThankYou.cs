using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

namespace EndingScene
{
    public class ThankYou : MonoBehaviour
    {
        public float Speed;
        public float OffsetToStop;

        private float totalOffset = 0;

        void Start()
        {
            if (Music.instance != null)
            {
                Music.instance.ToggleVolumeNoSave(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Make the customer walk to the middle.
            if (!(totalOffset <= OffsetToStop))
            {
                transform.position += new Vector3(Speed, 0, 0);
                totalOffset += Speed;
            }
        }
    }
}
