using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartStory
{
    public class Mayor : MonoBehaviour
    {
        public GameObject[] Dialogue;

        private Animator animator;
        
        private List<DialoguePanel> DialoguePanel;

        // Use this for initialization
        void Start()
        {
            animator = gameObject.GetComponent<Animator>();

            DialoguePanel = new List<DialoguePanel>();
            foreach (GameObject dialogue in Dialogue)
            {
                DialoguePanel.Add(dialogue.GetComponent<DialoguePanel>());
            }

            foreach (DialoguePanel dialoguePanel in DialoguePanel)
            {
                dialoguePanel.DialogueStarted += DialoguePanel_DialogueStarted;
                dialoguePanel.DialogueFinished += DialoguePanel_DialogueFinished;
            }
            
            animator.SetTrigger("IsTalking");
        }

        private void DialoguePanel_DialogueFinished(object sender, System.EventArgs e)
        {
            animator.SetTrigger("IsIdle");
        }

        private void DialoguePanel_DialogueStarted(object sender, System.EventArgs e)
        {
            animator.SetTrigger("IsTalking");
        }
    }
}

