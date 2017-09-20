using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StallSpace;
using Progress;
using System;
using Audio;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// The button which adds stock to the selected stall.
    /// </summary>
    public class AddStockButton : MonoBehaviour, IPointerClickHandler
    {
        [HideInInspector]
        public static event EventHandler RestockedClicked;

        public GameObject WarningText;

        public AudioClip ClickSound;
        private AudioSource source;

        /// <summary>
        /// The amount of how much the stall's stock increase when clicking this button.
        /// </summary>
        public int StockIncreaseAmount = 5;

        void Start()
        {
            source = gameObject.GetComponent<AudioSource>();

            Sound.SetSound(source, 0.3f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // The current selected stall.
            Stall selectedStall = UIManager.instance.SelectedStallSpace.GetComponent<Stall>();
            
            // Allow to restock if the player has enough money and if the stall's stock is already not at max.
            if (ProgressManager.Money - selectedStall.StallRestockCost >= 0)
            {
                if (selectedStall.StockCount + StockIncreaseAmount <= selectedStall.MaxStockCount)
                {
                    // Update the profit tracker.
                    ProfitTracker.instance.StallProfit[selectedStall.StallSpaceNumber] -= selectedStall.StallRestockCost;

                    // Decrease the player's money by the cost of restocking.
                    ProgressManager.Money -= selectedStall.StallRestockCost;
                    // Increase the stall's stock.
                    selectedStall.StockCount += StockIncreaseAmount;

                    PlaySound();
                }
                else
                {
                    WarningText.GetComponent<Text>().text = "Stall Full";
                    Instantiate(WarningText, gameObject.transform.parent.parent);
                }
            }
            else
            {
                WarningText.GetComponent<Text>().text = "Not Enough Money";
                Instantiate(WarningText, gameObject.transform.parent.parent);
            }

            OnRestockClicked();
        }

        private void PlaySound()
        {
            source.clip = ClickSound;
            source.Play();
        }

        private void OnRestockClicked()
        {
            if (RestockedClicked != null)
            {
                RestockedClicked(this, EventArgs.Empty);
            }
        }
    }
}