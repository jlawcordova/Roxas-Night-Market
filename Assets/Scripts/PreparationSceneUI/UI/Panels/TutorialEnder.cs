using UnityEngine;
using Progress;
using PreparationScene.UI.Buttons;

public class TutorialEnder : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        ProgressManager.TutorialMode = false;
        ProgressManager.SaveProgressToFile();

        gameObject.GetComponent<DialoguePanel>().AllDialogueFinished += TutorialEnder_AllDialogueFinished;
	}

    private void TutorialEnder_AllDialogueFinished(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }
}
