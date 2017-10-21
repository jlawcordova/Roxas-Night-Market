using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Audio;

namespace EndingScene
{
    /// <summary>
    /// Handles the continue button for the win scene.
    /// </summary>
    public class WinContinueButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false)
            {
                Music.instance.ToggleVolumeNoSave(true);
            }

            PlayerPrefs.SetInt("EndingCompleted", 1);
            SceneManager.LoadScene("PreparationScene");
        }
    }
}