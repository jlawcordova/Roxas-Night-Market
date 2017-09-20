using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparationScene.UI.Panels
{
    public class MayorEnder : MonoBehaviour
    {
        public GameObject Dialogue;

        // Use this for initialization
        void Start()
        {
            Dialogue.GetComponent<DialoguePanel>().AllDialogueFinished += TutorialEnder_AllDialogueFinished;
        }

        private void TutorialEnder_AllDialogueFinished(object sender, System.EventArgs e)
        {
            Destroy(gameObject);
        }
    }
}

