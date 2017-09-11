using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Audio;

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

            switch (PurchaseInformation.Type)
            {
                case PurchaseType.BuyStall:
                    SceneManager.LoadScene("PreparationScene");

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