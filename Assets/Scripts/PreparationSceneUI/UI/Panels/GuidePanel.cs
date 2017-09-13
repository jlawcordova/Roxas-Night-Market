using UnityEngine;

namespace PreparationScene.UI.Panels
{
    public class GuidePanel : MonoBehaviour
    {
        public GameObject CameraObject;
        public int XDisplacementToDestroy;

        [HideInInspector]
        public static bool IsShown = false;

        private Vector3 cameraStartingPosition;

        // Use this for initialization
        void Start()
        {
            gameObject.SetActive(IsShown);

            IsShown = false;
            cameraStartingPosition = CameraObject.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (CameraObject.transform.position.x - cameraStartingPosition.x >= XDisplacementToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}