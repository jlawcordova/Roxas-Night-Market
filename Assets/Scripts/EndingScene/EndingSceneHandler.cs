using Audio;
using Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndingScene
{
    public class EndingSceneHandler : MonoBehaviour
    {
        public GameObject Mayor;
        public GameObject NetworthCalculator;

        public GameObject Dialogue0PanelObject;
        public GameObject Dialogue1PanelObject;

        public GameObject FadingObject;

        public GameObject CameraObject;

        private bool moveCamera = false;
        private int networth;

        // Use this for initialization
        void Start()
        {
            // Get the networth.
            networth = NetworthCalculator.GetComponent<NetworthCalculator>().CalculateNetworth();
            // Set the dialogue text depending on the networth.
            Dialogue1PanelObject.GetComponent<DialoguePanel>().Dialogues[1] = "... Roxas Night Market's net worth is valued at " + networth + " coins!";
            if (networth < 30000)
            {
                Dialogue1PanelObject.GetComponent<DialoguePanel>().Dialogues[2] = "It seems like you haven't made the Roxas Night Market as great and profitable as I wanted it to be.";
                Dialogue1PanelObject.GetComponent<DialoguePanel>().Dialogues[3] = "I'm sorry, but I have to close down the Market and turn it into an avenue again.";
            }

            Dialogue0PanelObject.SetActive(true);
            Dialogue1PanelObject.SetActive(false);
            
            Dialogue0PanelObject.GetComponent<DialoguePanel>().AllDialogueFinished += EndingSceneHandler_AllDialogue0Finished;
            Dialogue1PanelObject.GetComponent<DialoguePanel>().AllDialogueFinished += EndingSceneHandler_AllDialogue1Finished; ;
        }

        /// <summary>
        /// Occurs when the dialogue 0 object has finsihed all dialogue.
        /// Moves the camera to right endpoint, then displays the next dialogue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndingSceneHandler_AllDialogue0Finished(object sender, System.EventArgs e)
        {
            moveCamera = true;
            Dialogue0PanelObject.SetActive(false);
            Mayor.SetActive(false);
        }

        /// <summary>
        /// Occurs when the dialogue 1 object has finsihed all dialogue.
        /// Moves to the next scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndingSceneHandler_AllDialogue1Finished(object sender, System.EventArgs e)
        {
            if (networth < 30000)
            {
                FadingObject.GetComponent<FadeToSceneObject>().SceneName = "LoseScene";
                FadingObject.SetActive(true);
            }
            else
            {
                FadingObject.GetComponent<FadeToSceneObject>().SceneName = "WinScene";
                FadingObject.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (moveCamera)
            {
                CameraObject.transform.position = new Vector3(CameraObject.transform.position.x+0.02f, 0, -10);
                if (CameraObject.transform.position.x >= 12f * Progress.ProgressManager.PlaceSize)
                {
                    moveCamera = false;
                    Dialogue1PanelObject.SetActive(true);
                    Mayor.SetActive(true);
                }
            }
        }
    }
}

