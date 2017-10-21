using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Audio;
using Progress;

namespace EndingScene
{
    public class LoseContinueButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            // Reset the profit tracker, music and save file.
            PlayerPrefs.SetInt("EndingCompleted", 1);

            if (ProfitTracker.instance != null)
            {
                Destroy(ProfitTracker.instance.gameObject);
            }
            
            ProgressManager.DeleteSaveFile();


            SceneManager.LoadScene("LogoScene");
        }

    }
}

