using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartStory
{
    /// <summary>
    /// Handles the mayor object which is the one who speaks the dialogues.
    /// </summary>
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
            
            // Make the Mayor do something for every dialogue event.
            foreach (DialoguePanel dialoguePanel in DialoguePanel)
            {
                dialoguePanel.DialogueStarted += DialoguePanel_DialogueStarted;
                dialoguePanel.DialogueFinished += DialoguePanel_DialogueFinished;
            }
            
            animator.SetTrigger("IsTalking");
        }

        /// <summary>
        /// Occurs when a dialogue has been finished. Makes the mayor go into idle mode.
        /// </summary>
        private void DialoguePanel_DialogueFinished(object sender, System.EventArgs e)
        {
            animator.SetTrigger("IsIdle");
        }

        /// <summary>
        /// Occurs when a dialogue has been started. Makes the mayor go into talking mode.
        /// </summary>
        private void DialoguePanel_DialogueStarted(object sender, System.EventArgs e)
        {
            animator.SetTrigger("IsTalking");
        }
    }
}

