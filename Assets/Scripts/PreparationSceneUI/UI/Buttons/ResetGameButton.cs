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
        public GameObject ResetConfirmationPanel;

        /// <summary>
        /// Occurs when clicking the reset game button.
        /// </summary>
        /// <param name="eventData">Pointer click event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            ResetConfirmationPanel.SetActive(true);
        }
    }
}

