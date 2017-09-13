using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Audio;
using Progress;
using StartStory;

namespace Purchase.UI.Buttons
{
    /// <summary>
    /// Handles the ok button.
    /// </summary>
    public class OkButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when clicking the Ok button
        /// </summary>
        /// <param name="eventData">Data on the event</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (PlayerPrefs.GetInt("MusicVolume") == 1 ? true : false)
            {
                Music.instance.ToggleVolumeNoSave(true);
            }

            // Load the preparation scene when a stall is bought while also checking for unlocks.
            // Load the purchase scene again when an upgrade is bought.
            switch (PurchaseInformation.Type)
            {
                case PurchaseType.BuyStall:
                    // Check if the game is in tutorial mode.
                    if (ProgressManager.TutorialMode)
                    {
                        TutorialHandler.TutorialNumber = 2;
                        SceneManager.LoadScene("TutorialPreparationScene");
                    }
                    else
                    {
                        // Check Place Size Unlock
                        if (ProgressManager.CheckPlaceSizeUpgrade())
                        {
                            SceneManager.LoadScene("UnlockedScene");
                        }
                        else
                        {
                            SceneManager.LoadScene("PreparationScene");
                        }
                    }

                    break;
                case PurchaseType.UpgradeStall:
                    SceneManager.LoadScene("PurchaseScene");

                    break;
                default:
                    break;
            }
        }
    }
}