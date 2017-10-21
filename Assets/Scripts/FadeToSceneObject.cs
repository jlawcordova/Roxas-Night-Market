using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToSceneObject : MonoBehaviour
{
    public string SceneName;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadingOut());
    }

    // Wait until the object fades to move to the next scene.
    IEnumerator FadingOut()
    {
        yield return new WaitUntil(() => transform.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene(SceneName);
    }
}
