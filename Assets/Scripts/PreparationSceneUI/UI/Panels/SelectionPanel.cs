using System.Collections.Generic;
using UnityEngine;
using StallSpace;

namespace PreparationScene.UI.Panels
{
    /// <summary>
    /// The UI panel that will be displayed when clicking stalls and empty stalls.
    /// </summary>
    public class SelectionPanel : MonoBehaviour
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
        /// The initial position of the panel on the screen.
        /// </summary>
        public float InitialPanelYPosition;
        /// <summary>
        /// The final position of the panel.
        /// </summary>
        public float FinalPanelYPosition;
        /// <summary>
        /// The speed of the panel animation.
        /// </summary>
        public float PanelSpeed = 1f;

        /// <summary>
        /// Flag to indicate that the panel is going down.
        /// </summary>
        private bool goingUp = false;
        /// <summary>
        /// Flag to indicate that the panel is going up.
        /// </summary>
        private bool goingDown = false;
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
        public GameObject AddStockButton;
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
            // Set the panel's position to be on the upper middle location.
            InitialPanelPosition = new Vector3(0, InitialPanelYPosition, 0);
            FinalPanelPosition = new Vector3(0, FinalPanelYPosition, 0);

            // Create a new list for the buttons on the panel.
            ButtonsOnPanel = new List<GameObject>();

            // Place the panel hidden from the camera.
            transform.position = InitialPanelPosition;
        }

        /// <summary>
        /// Called once per frame.
        /// </summary>
        void Update()
        {
            // If the panel is set to go down, move it down.
            if (goingUp)
            {
                if (transform.position.y < FinalPanelPosition.y)
                {
                    transform.position += new Vector3(0, PanelSpeed, 0);
                }
                else
                {
                    // Stop the panel from going down once it reaches the end location.
                    goingUp = false;
                }
            }
            // If the panel is set to go up, move it up.
            if (goingDown)
            {
                if (transform.position.y >= InitialPanelPosition.y)
                {
                    transform.position -= new Vector3(0, PanelSpeed, 0);
                }
                else
                {
                    RemoveButtons();

                    // Stop the panel from going up once it reaches the end location.
                    goingDown = false;
                    // If the panel was resetting, move it down again.
                    if (resetting)
                    {
                        GoUp();
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
        public void GoUp()
        {
            // Remove the buttons that are on the panel.
            RemoveButtons();

            // Fill the panel with buttons depending on the selected object.
            switch (UIManager.instance.SelectedStallSpaceType)
            {
                case StallSpaceType.EmptyStall:
                    ButtonsOnPanel.Add(Instantiate(BuyStallButton, transform));
                    break;
                case StallSpaceType.KwekKwekStall:
                    FillAllButtons();

                    break;
                case StallSpaceType.IsawStall:
                    FillAllButtons();

                    break;
                case StallSpaceType.IcecreamStall:
                    FillAllButtons();

                    break;
                case StallSpaceType.FruitShakeStall:
                    FillAllButtons();

                    break;
                case StallSpaceType.Fountain:
                    if (UpgradeStallButton != null)
                    {
                        ButtonsOnPanel.Add(Instantiate(UpgradeStallButton, transform));
                    }
                    if (SellStallButton != null)
                    {
                        ButtonsOnPanel.Add(Instantiate(SellStallButton, transform));
                    }

                    break;
                default:
                    throw new System.ArgumentException("Clicked object type invalid.");
            }

            goingDown = false;
            goingUp = true;
        }

        public void FillAllButtons()
        {
            ButtonsOnPanel.Add(Instantiate(AddStockButton, transform));
            if (UpgradeStallButton != null)
            {
                ButtonsOnPanel.Add(Instantiate(UpgradeStallButton, transform));
            }
            if (SellStallButton != null)
            {
                ButtonsOnPanel.Add(Instantiate(SellStallButton, transform));
            }
        }

        /// <summary>
        /// Moves the panel up, then down.
        /// </summary>
        public void Reset()
        {
            goingDown = true;
            goingUp = false;
            resetting = true;
        }

        /// <summary>
        /// Moves the panel up.
        /// </summary>
        public void GoDown()
        {
            goingUp = false;
            goingDown = true;
        }
    }
}