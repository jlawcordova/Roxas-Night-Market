using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Progress;
using UnlockedScene;
//using UnityEngine.Advertisements;

namespace DaySimulation.UI.Buttons
{
    /// <summary>
    /// Handles the ok button.
    /// </summary>
    public class OkButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the ok button is clicked.
        /// </summary>
        /// <param name="eventData">Pointer click event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            SpeedManager.instance.SetToNormalSpeed();
            
            // Check if the game has reached its endpoint.
            if (ProgressManager.CheckGameEnd())
            {
                PlayerPrefs.SetInt("EndingCompleted", 0);
                SceneManager.LoadScene("GoodEndingScene");
            }
            else
            {
                int unlockedCustomerNumber;

                // Check if a customer is unlocked.
                if (ProgressManager.CheckCustomerUnlock(out unlockedCustomerNumber))
                {
                    UnlockCustomerInformation.CustomerNumber = unlockedCustomerNumber;
                    SceneManager.LoadScene("UnlockedCustomerScene");
                }
                else
                {
                    // Just load normally if no customer is unlocked.
                    ProfitTracker.instance.Reset();

                    //Advertisement.Show();
                    SceneManager.LoadScene("PreparationScene");
                }
            }
        }
    }
}