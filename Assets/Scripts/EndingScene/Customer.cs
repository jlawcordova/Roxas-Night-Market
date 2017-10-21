using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndingScene
{
    /// <summary>
    /// Handles the customers in the end win scene.
    /// </summary>
    public class Customer : MonoBehaviour
    {
        public GameObject[] hiddenObjects;

        public float Speed;
        public float OffsetToStop;
        public float PauseTime;

        private float totalOffset = 0;
        private float totalPauseTime = 0;
        private Animator animator;

        private bool iPlacing = false;

        // Use this for initialization
        void Start()
        {
            // The customer serves as the basis for enabling some UI.
            foreach (GameObject hiddenObject in hiddenObjects)
            {
                hiddenObject.SetActive(false);
            }
            
            animator = gameObject.GetComponent<Animator>();
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
            else
            {
                // Make the customer pause.
                if (!iPlacing)
                {
                    animator.SetTrigger("IsWalkingUp");
                    animator.SetTrigger("IsIdle");
                    iPlacing = true;
                }
                
                totalPauseTime++;
                // Make the customer walk again after some time.
                if (totalPauseTime >= PauseTime)
                {
                    totalOffset = 0;
                    animator.SetTrigger("IsWalking");
                    foreach (GameObject hiddenObject in hiddenObjects)
                    {
                        hiddenObject.SetActive(true);
                    }
                }
            }
        }
    }
}

