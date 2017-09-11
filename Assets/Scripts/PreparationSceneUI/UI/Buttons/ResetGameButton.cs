using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Audio;
using Progress;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the reset game button.
    /// </summary>
    public class ResetGameButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when clicking the reset game button.
        /// </summary>
        /// <param name="eventData">Pointer click event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            // TODO Show an are you sure dialogue box first.
            ProgressManager.DeleteSaveFile();
            Destroy(Music.instance.gameObject);
            SceneManager.LoadScene("LogoScene");
        }
    }
}

