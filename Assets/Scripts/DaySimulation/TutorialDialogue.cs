using UnityEngine;
using Progress;

public class TutorialDialogue : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (!ProgressManager.TutorialMode)
        {
            gameObject.SetActive(false);
        }
        else
        {
            ProgressManager.SaveProgressToFile();
        }
	}
}
