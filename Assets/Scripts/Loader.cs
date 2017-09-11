using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
    public int Time = 300;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time <= 0)
        {
            SceneManager.LoadScene("MainScreenScene");
        }
        Time--;
	}
}
