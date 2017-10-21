using UnityEngine;

namespace Mainscreen
{
    public class GameLogo : MonoBehaviour
    {
        public Vector3 FinalPosition;

        public GameObject FadingObject;
        public GameObject[] EnableObjects;

        public float YSpeed;

        void Start()
        {
            FadingObject.SetActive(false);

            foreach (GameObject enableObject in EnableObjects)
            {
                enableObject.SetActive(false);
            }
        }

        // Use this for initialization
        void Update()
        {
            if (transform.position.y > FinalPosition.y)
            {
                transform.position -= new Vector3(0, YSpeed, 0);
            }
            else
            {
                foreach (GameObject enableObject in EnableObjects)
                {
                    enableObject.SetActive(true);
                }
            }
        }
    }

}