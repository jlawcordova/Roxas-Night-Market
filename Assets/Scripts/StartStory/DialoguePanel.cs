using Audio;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    /// <summary>
    /// The dialogues to be played.
    /// </summary>
    [TextArea]
    public string[] Dialogues;
    private StringBuilder displayedDialogue;

    /// <summary>
    /// The name of the speaker of the dialogue.
    /// </summary>
    public string SpeakerName;

    /// <summary>
    /// The index of the current dialogue line being played.
    /// </summary>
    [HideInInspector]
    public int CurrentDialogueIndex = 0;
    private int currentDialogueStringIndex = 0;

    /// <summary>
    /// The sound to play when displaying a letter.
    /// </summary>
    public AudioClip TextDisplaySound;
    private AudioSource source;

    /// <summary>
    /// The slow delay when displaying each character.
    /// </summary>
    public int SlowTextDelay;
    /// <summary>
    /// The fast delay when displaying each character.
    /// </summary>
    public int FastTextDelay;

    /// <summary>
    /// The amount of delay being used when displaying each character.
    /// </summary>
    private int textDelay;
    /// <summary>
    /// A counter used for detecting how much delay has lapsed.
    /// </summary>
    private int currentDelayCount = 0;

    /// <summary>
    /// The text and gameobjects of the different children in this gameobject.
    /// </summary>
    private Text dialogueText;
    private GameObject dialogueTextObject;
    private GameObject continueTextObject;

    /// <summary>
    /// The indexes of the different children in this gameobject.
    /// </summary>
    private const int DialogueTextIndex = 0;
    private const int ContinueTextIndex = 1;

    /// <summary>
    /// Informs listeners that a dialogue line has started playing.
    /// </summary>
    public event EventHandler DialogueStarted;
    /// <summary>
    /// Informs listeners that a dialogue line has been displayed fully.
    /// </summary>
    public event EventHandler DialogueFinished;
    /// <summary>
    /// Informs listeners that a all dialogue lines have finished.
    /// </summary>
    public event EventHandler AllDialogueFinished;

    private bool allDialogueFinishedFlag = false;

    /// <summary>
    /// The current status of the dialogue.
    /// </summary>
    private DialogueStatus currentDialogueStatus;
    private enum DialogueStatus
    {
        Playing,
        Ended,
        Waiting
    }


    // Use this for initialization
    void Start ()
    {
        source = gameObject.GetComponent<AudioSource>();
        // Set the sound of this object.
        Sound.SetSound(source, 0.3f);

        // Set the texts and gameobjects.
        dialogueText = transform.GetChild(DialogueTextIndex).GetComponent<Text>();
        continueTextObject = transform.GetChild(ContinueTextIndex).gameObject;

        // Set the initial condition of the dialogue.
        displayedDialogue = new StringBuilder(SpeakerName + ": ");
        dialogueText.text = displayedDialogue.ToString();

        continueTextObject.SetActive(false);

        currentDialogueStatus = DialogueStatus.Playing;
        textDelay = SlowTextDelay;

        OnDialogueStarted();
    }

    void PlayDisplaySound()
    {
        source.clip = TextDisplaySound;

        source.Play();
    }

    // Update is called once per frame
    void Update ()
    {
        switch (currentDialogueStatus)
        {
            case DialogueStatus.Playing:
                // Perform the delay.
                if (currentDelayCount < textDelay)
                {
                    currentDelayCount++;
                }
                else
                {
                    // Append a character to the displayed text.
                    if (currentDialogueStringIndex < Dialogues[CurrentDialogueIndex].Length)
                    {
                        displayedDialogue.Append(Dialogues[CurrentDialogueIndex][currentDialogueStringIndex]);
                        dialogueText.text = displayedDialogue.ToString();

                        if (textDelay == SlowTextDelay)
                        {
                            PlayDisplaySound();
                        }

                        currentDialogueStringIndex++;
                        currentDelayCount = 0;
                    }
                    else
                    {
                        // End the display and make the dialogue slow again.
                        textDelay = SlowTextDelay;
                        currentDialogueStatus = DialogueStatus.Ended;
                    }
                }

                break;

            case DialogueStatus.Ended:
                // Set the next dialogue to be played.
                if (CurrentDialogueIndex + 1 < Dialogues.Length)
                {
                    OnDialogueFinished();
                    continueTextObject.SetActive(true);

                    CurrentDialogueIndex++;

                    displayedDialogue = new StringBuilder(SpeakerName + ": ");
                    currentDialogueStringIndex = 0;
                }
                else
                {
                    OnDialogueFinished();
                    OnAllDialogueFinished();

                    allDialogueFinishedFlag = true;
                }
                
                currentDialogueStatus = DialogueStatus.Waiting;

                break;

            case DialogueStatus.Waiting:
                break;
            default:
                break;
        }

        // Check when the user clicks.
        if (Input.GetMouseButtonUp(0))
        {
            switch (currentDialogueStatus)
            {
                case DialogueStatus.Playing:
                    // Make the text appear faster.
                    textDelay = FastTextDelay;

                    break;
                case DialogueStatus.Waiting:
                    // Play the next dialogue.
                    continueTextObject.SetActive(false);
                    currentDialogueStatus = DialogueStatus.Playing;
                    if (!allDialogueFinishedFlag)
                    {
                        OnDialogueStarted();
                    }

                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Occurs when a dialogue has finished playing.
    /// </summary>
    void OnDialogueStarted()
    {
        if (DialogueStarted != null)
        {
            DialogueStarted(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Occurs when a dialogue has finished playing.
    /// </summary>
    void OnDialogueFinished()
    {
        if (DialogueFinished != null)
        {
            DialogueFinished(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Occurs when all dialogue have finished playing.
    /// </summary>
    void OnAllDialogueFinished()
    {
        if (AllDialogueFinished != null)
        {
            AllDialogueFinished(this, EventArgs.Empty);
        }
    }
}
