using UnityEngine;
using Progress;

public class TutorialDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!ProgressManager.TutorialMode)
        {
            gameObject.SetActive(false);
        }
	}
}
