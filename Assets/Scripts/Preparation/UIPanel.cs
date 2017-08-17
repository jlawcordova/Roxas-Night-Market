using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Preparation
{
    /// <summary>
    /// The UI panel that will be displayed when clicking stalls and empty stalls.
    /// </summary>
    public class UIPanel : MonoBehaviour
    {
        /// <summary>
        /// The initial position of the panel on the screen.
        /// </summary>
        private Vector3 InitialPanelPosition;
        /// <summary>
        /// The final position of the panel.
        /// </summary>
        private Vector3 FinalPanelPosition;
        /// <summary>
        /// The speed of the panel animation.
        /// </summary>
        public float PanelSpeed = 1f;

        /// <summary>
        /// Flag to indicate that the panel is going down.
        /// </summary>
        private bool goingDown = false;
        /// <summary>
        /// Flag to indicate that the panel is going up.
        /// </summary>
        private bool goingUp = false;
        /// <summary>
        /// Flag to indicate that the panel is resetting.
        /// </summary>
        private bool resetting = false;

        /// <summary>
        /// The buy stall button.
        /// </summary>
        public GameObject BuyStallButton;
        /// <summary>
        /// The upgrade stall button.
        /// </summary>
        public GameObject UpgradeStallButton;
        /// <summary>
        /// The sell stall button.
        /// </summary>
        public GameObject SellStallButton;

        /// <summary>
        /// The list of buttons that are currently on a panel.
        /// </summary>
        private List<GameObject> ButtonsOnPanel;

        /// <summary>
        /// Initialization of the selection panel.
        /// </summary>
        void Start()
        {
            InitialPanelPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height + transform.GetComponent<RectTransform>().rect.height, transform.parent.transform.position.z));
            FinalPanelPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height - transform.GetComponent<RectTransform>().rect.height/2, transform.parent.transform.position.z));
            ButtonsOnPanel = new List<GameObject>();
            transform.position = InitialPanelPosition;
        }

        /// <summary>
        /// Called once per frame.
        /// </summary>
        void Update()
        {
            // If the panel is set to go down, move it down.
            if (goingDown)
            {
                if (transform.position.y > FinalPanelPosition.y)
                {
                    transform.position -= new Vector3(0, PanelSpeed, 0);
                }
                else
                {
                    // Stop the panel from going down once it reaches the end location.
                    goingDown = false;
                }
            }
            // If the panel is set to go up, move it up.
            if (goingUp)
            {
                if (transform.position.y < InitialPanelPosition.y)
                {
                    transform.position += new Vector3(0, PanelSpeed, 0);
                }
                else
                {
                    RemoveButtons();

                    // Stop the panel from going up once it reaches the end location.
                    goingUp = false;
                    // If the panel was resetting, move it down again.
                    if (resetting)
                    {
                        GoDown();
                        resetting = false;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the buttons on the panel.
        /// </summary>
        private void RemoveButtons()
        {
            foreach (GameObject button in ButtonsOnPanel)
            {
                Destroy(button);
            }
        }

        /// <summary>
        /// Moves the panel down.
        /// </summary>
        public void GoDown()
        {
            // Remove the buttons that are on the panel.
            RemoveButtons();

            // Fill the panel with buttons depending on the selected object.
            switch (UIManager.instance.SelectedObjectType)
            {
                case SelectableObjectType.EmptyStall:
                    ButtonsOnPanel.Add(Instantiate(BuyStallButton, transform));
                    break;
                case SelectableObjectType.Stall:
                    ButtonsOnPanel.Add(Instantiate(UpgradeStallButton, transform));
                    ButtonsOnPanel.Add(Instantiate(SellStallButton, transform));
                    break;
                default:
                    throw new System.ArgumentException("Clicked object type invalid.");
            }

            goingUp = false;
            goingDown = true;
        }

        /// <summary>
        /// Moves the panel up, then down.
        /// </summary>
        public void Reset()
        {
            goingUp = true;
            goingDown = false;
            resetting = true;
        }

        /// <summary>
        /// Moves the panel up.
        /// </summary>
        public void GoUp()
        {
            goingDown = false;
            goingUp = true;
        }
    }
}