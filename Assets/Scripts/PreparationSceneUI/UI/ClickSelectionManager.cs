using UnityEngine;
using StallSpace;
using PreparationScene.UI.Panels;

namespace PreparationScene.UI
{
    /// <summary>
    /// Manages user clicking and selection.
    /// </summary>
    public class ClickSelectionManager : MonoBehaviour
    {
        [HideInInspector]
        public static ClickSelectionManager instance;

        /// <summary>
        /// The layer mask of the empty stall.
        /// </summary>
        public LayerMask EmptyStallLayer;
        /// <summary>
        /// The layer mask of the clickable stall.
        /// </summary>
        public LayerMask StallLayer;
        
        /// <summary>
        /// Temporary variable used to store the hit object by the mouse click raycast.
        /// </summary>
        private RaycastHit2D selectedHit;

        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            // Check if mouse has been clicked.
            if (Input.GetMouseButtonDown(0))
            {
                // Create a raycast object to check if the mouse has hit an empty stall on screen.
                Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                // Flag to indicate that an object has been hit.
                bool didHitObject = false;

                // Check if an empty stall is hit.
                didHitObject = CheckRaycastHitToBringDownPanel(ray, EmptyStallLayer, StallSpaceType.EmptyStall);

                // Check if a stall is clicked.
                if (!didHitObject)
                {
                    didHitObject = CheckRaycastHitToBringDownPanel(ray, StallLayer, StallSpaceType.KwekKwekStall);
                }

                // Check if nothing is clicked.
                // If the click is below the panel with nothing hit, make the panel go up.
                if (!didHitObject &&
                    Input.mousePosition.y > (Camera.main.WorldToScreenPoint(UIManager.instance.DisplayedSelectionPanel.transform.position) 
                    + new Vector3(0, UIManager.instance.DisplayedSelectionPanel.GetComponent<RectTransform>().rect.height / 2, 0)).y)
                {
                    UIManager.instance.SelectedStallSpace = null;
                    UIManager.instance.DisplayedSelectionPanel.GetComponent<SelectionPanel>().GoDown();
                }
            }
        }

        /// <summary>
        /// Casts a ray on the screen and checks if an object with the specified layer mask is hit and bring down the selection panel accordingly.
        /// Also sets the UIManager's selected object type to the specified SelectableObjectType.
        /// </summary>
        /// <param name="ray">The ray that tries to hit an object which is on the specified layer mask.</param>
        /// <param name="layerMask">The layer mask of the object that the ray must hit.</param>
        /// <param name="stallSpaceType">The SelectableObjectType that will set the UIManager's selected stall space type if an object is hit.</param>
        /// <returns></returns>
        bool CheckRaycastHitToBringDownPanel(Vector2 ray, LayerMask layerMask, StallSpaceType stallSpaceType)
        {
            selectedHit = Physics2D.Raycast(ray, Vector2.zero, 0f, layerMask);
            if (selectedHit)
            {
                // Check if an object has already been selected.
                // If no object has been selected yet, just bring down the panel.
                if (UIManager.instance.SelectedStallSpace == null)
                {
                    UIManager.instance.SelectedStallSpace = selectedHit.transform.gameObject;
                    UIManager.instance.LastSelectedStallSpace = selectedHit.transform.gameObject;
                    UIManager.instance.SelectedStallSpaceType = stallSpaceType;
                    UIManager.instance.DisplayedSelectionPanel.GetComponent<SelectionPanel>().GoUp();
                }
                // Reset the panel if a new object has been selected.
                else if (selectedHit.transform.gameObject != UIManager.instance.SelectedStallSpace)
                {
                    UIManager.instance.SelectedStallSpace = selectedHit.transform.gameObject;
                    UIManager.instance.LastSelectedStallSpace = selectedHit.transform.gameObject;
                    UIManager.instance.SelectedStallSpaceType = stallSpaceType;
                    UIManager.instance.DisplayedSelectionPanel.GetComponent<SelectionPanel>().Reset();
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}