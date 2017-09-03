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
        private Text currentMoneyText;

        public GameObject MoneyChangeText;
        private int PreviousMoney;
        
        /// <summary>
        /// Initialization of the money text.
        /// </summary>
        void Start()
        {
            currentMoneyText = gameObject.GetComponent<Text>();

            PreviousMoney = ProgressManager.Money;

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
            if (currentMoneyText != null)
            {
                UpdateMoneyText();
            }
        }

        /// <summary>
        /// Updates the money text.
        /// </summary>
        public void UpdateMoneyText()
        {
            int change = ProgressManager.Money - PreviousMoney;
            if (change!=0)
            {
                GameObject changeText = Instantiate(MoneyChangeText, transform.parent);
                changeText.GetComponent<Text>().text = (change > 0 ? "+" : "") + change.ToString();

                if (change > 0)
                {
                    changeText.GetComponent<MoneyChangeText>().UseIncreaseColor();
                }
                else
                {
                    changeText.GetComponent<MoneyChangeText>().UseDecreaseColor();
                }
            }

            currentMoneyText.text = ProgressManager.Money.ToString();

            PreviousMoney = ProgressManager.Money;
        }
    }
}