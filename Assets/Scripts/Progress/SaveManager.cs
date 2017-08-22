using Progress;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        // TODO Get stall space information from save file.
        ProgressManager.GetProgressFromFile();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
