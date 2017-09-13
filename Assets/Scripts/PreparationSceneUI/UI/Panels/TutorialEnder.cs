using UnityEngine;
using Progress;
using PreparationScene.UI.Buttons;

public class TutorialEnder : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<DialoguePanel>().AllDialogueFinished += TutorialEnder_AllDialogueFinished;
	}

    private void TutorialEnder_AllDialogueFinished(object sender, System.EventArgs e)
    {
        ProgressManager.TutorialMode = false;
        ProgressManager.SaveProgressToFile();

        Destroy(gameObject);
    }
}
