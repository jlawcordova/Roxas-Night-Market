using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    // The time it takes before moving to the next scene.
    public int Time = 300;

	// Update is called once per frame
	void Update ()
    {
        if (Time <= 0)
        {
            SceneManager.LoadScene("MainScreenScene");
        }
        Time--;
	}
}
