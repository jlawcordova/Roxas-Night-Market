using UnityEngine;
using UnityEngine.UI;
using Progress;

namespace PreparationScene.UI.Texts
{
    /// <summary>
    /// Displays the current amount of money the player has.
    /// </summary>
    public class MoneyText : MonoBehaviour
    {
        // This money text.
        public Text CurrentMoneyText;
        
        /// <summary>
        /// Initialization of the money text.
        /// </summary>
        void Start()
        {
            CurrentMoneyText = gameObject.GetComponent<Text>();

            ProgressManager.MoneyUpdated += ProgressManager_MoneyUpdated;
            UpdateMoneyText();
        }

        /// <summary>
        /// Update the money text when the progress manager's money has been updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressManager_MoneyUpdated(object sender, System.EventArgs e)
        {
            // TODO Find out why the game keeps persisting the previous MoneyTexts even if another scene has been loaded.
            if (CurrentMoneyText != null)
            {
                UpdateMoneyText();
            }
        }

        /// <summary>
        /// Updates the money text.
        /// </summary>
        public void UpdateMoneyText()
        {
            CurrentMoneyText.text = ProgressManager.Money.ToString();
        }
    }
}