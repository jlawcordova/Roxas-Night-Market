using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Progress;
using Audio;

namespace PreparationScene.UI.Buttons
{
    public class ResetYesButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the sell stall button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            // Reset the profit tracker, music and save file.
            Destroy(ProfitTracker.instance.gameObject);
            ProgressManager.DeleteSaveFile();
            Destroy(Music.instance.gameObject);

            SceneManager.LoadScene("LogoScene");
        }
    }

}