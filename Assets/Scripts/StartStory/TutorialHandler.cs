using PreparationScene.UI;
using PreparationScene.UI.Buttons;
using Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartStory
{
    /// <summary>
    /// Handles the tutorial in the preparation scene.
    /// </summary>
    public class TutorialHandler : MonoBehaviour
    {
        public static int TutorialNumber = 1;

        public GameObject Dialogue1PanelObject;
        public GameObject Dialogue2PanelObject;
        public GameObject Dialogue3PanelObject;
        public GameObject ClickSelection;
        public GameObject StartDay;

        public LayerMask NoneLayer;

        // Use this for initialization
        void Start()
        {
            if (TutorialNumber == 1)
            {
                ClickSelection.SetActive(false);
                Dialogue2PanelObject.SetActive(false);
                Dialogue3PanelObject.SetActive(false);

                StartDay.SetActive(false);

                Dialogue1PanelObject.GetComponent<DialoguePanel>().DialogueFinished += TutorialHandler_DialogueFinished1;
                Dialogue1PanelObject.GetComponent<DialoguePanel>().AllDialogueFinished += TutorialHandler_AllDialogueFinished1;
            }
            else if (TutorialNumber == 2)
            {
                TutorialNumber = 1;

                Dialogue1PanelObject.SetActive(false);
                Dialogue3PanelObject.SetActive(false);

                StartDay.SetActive(false);

                ClickSelection.GetComponent<ClickSelectionManager>().EmptyStallLayer = NoneLayer;

                AddStockButton.RestockedClicked += AddStockButton_RestockedClicked;
                Dialogue3PanelObject.GetComponent<DialoguePanel>().AllDialogueFinished += TutorialHandler_AllDialogueFinished3;
            }
        }

        private void TutorialHandler_DialogueFinished1(object sender, System.EventArgs e)
        {
            if (((DialoguePanel)sender).CurrentDialogueIndex == 1)
            {
                ProgressManager.Money += 2500;
            }
        }

        private void TutorialHandler_AllDialogueFinished1(object sender, System.EventArgs e)
        {
            ClickSelection.SetActive(true);
        }

        private void AddStockButton_RestockedClicked(object sender, System.EventArgs e)
        {
            Dialogue2PanelObject.SetActive(false);
            Dialogue3PanelObject.SetActive(true);
        }

        private void TutorialHandler_AllDialogueFinished3(object sender, System.EventArgs e)
        {
            AddStockButton.RestockedClicked -= AddStockButton_RestockedClicked;
            StartDay.SetActive(true);
        }
    }
}

