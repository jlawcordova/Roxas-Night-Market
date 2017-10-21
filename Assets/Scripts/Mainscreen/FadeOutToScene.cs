using Progress;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Mainscreen
{
    public class FadeOutToScene : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            StartCoroutine(FadingOut());
        }

        IEnumerator FadingOut()
        {
            yield return new WaitUntil(() => transform.GetComponent<Image>().color.a == 1);
            if (ProgressManager.TutorialMode)
            {
                SceneManager.LoadScene("StartStoryScene");
            }
            else
            {
                // Special case where the user has not finished the ending scene.
                if (ProgressManager.Day == 100)
                {
                    if (PlayerPrefs.GetInt("EndingCompleted") == 0)
                    {
                        SceneManager.LoadScene("GoodEndingScene");
                    }
                    else
                    {
                        SceneManager.LoadScene("PreparationScene");
                    }
                }
                else
                {
                    SceneManager.LoadScene("PreparationScene");
                }
            }
        }
    }
}

