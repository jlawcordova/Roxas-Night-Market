using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Preparation
{
    /// <summary>
    /// Manages the UI on the screen.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [HideInInspector]
        public static UIManager instance;

        /// <summary>
        /// The current selected object on the screen which this panel is representing.
        /// </summary>
        [HideInInspector]
        public GameObject SelectedObject = null;
        [HideInInspector]
        public SelectableObjectType SelectedObjectType;

        /// <summary>
        /// The selection panel that will appear when clicking the empty stall.
        /// </summary>
        public GameObject SelectionPanel;
        public Button DaySimulationButton;

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

        // Use this for initialization
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DaySimulationButton.GetComponent<Button>().onClick.AddListener(StartSimulation);
        }
        
        void StartSimulation()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// Called once every frame.
        /// </summary>
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
                didHitObject = CheckRaycastHitToBringDownPanel(ray, EmptyStallLayer, SelectableObjectType.EmptyStall);

                // Check if a stall is clicked.
                if (!didHitObject)
                {
                    didHitObject = CheckRaycastHitToBringDownPanel(ray, StallLayer, SelectableObjectType.Stall);
                }

                // Check if nothing is clicked.
                // If the click is below the panel with nothing hit, make the panel go up.
                if (!didHitObject && 
                    Input.mousePosition.y < (Camera.main.WorldToScreenPoint(SelectionPanel.transform.position) - new Vector3(0, SelectionPanel.GetComponent<RectTransform>().rect.height / 2, 0)).y)
                {
                    SelectedObject = null;
                    SelectionPanel.GetComponent<UIPanel>().GoUp();
                }
            }
        }

        /// <summary>
        /// Casts a ray on the screen and checks if an object with the specified layer mask is hit and bring down the selection panel accordingly.
        /// Also sets the UIManager's selected object type to the specified SelectableObjectType.
        /// </summary>
        /// <param name="ray">The ray that tries to hit an object which is on the specified layer mask.</param>
        /// <param name="layerMask">The layer mask of the object that the ray must hit.</param>
        /// <param name="clickedType">The SelectableObjectType that will set the UIManager's selected object type if an object is hit.</param>
        /// <returns></returns>
        bool CheckRaycastHitToBringDownPanel(Vector2 ray, LayerMask layerMask, SelectableObjectType clickedType)
        {
            selectedHit = Physics2D.Raycast(ray, Vector2.zero, 0f, layerMask);
            if (selectedHit)
            {
                // Check if an object has already been selected.
                // If no object has been selected yet, just bring down the panel.
                if (SelectedObject == null)
                {
                    SelectedObject = selectedHit.transform.gameObject;
                    SelectedObjectType = clickedType;
                    SelectionPanel.GetComponent<UIPanel>().GoDown();
                }
                // Reset the panel if a new object has been selected.
                else if (selectedHit.transform.gameObject != SelectedObject)
                {
                    SelectedObject = selectedHit.transform.gameObject;
                    SelectedObjectType = clickedType;
                    SelectionPanel.GetComponent<UIPanel>().Reset();
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
