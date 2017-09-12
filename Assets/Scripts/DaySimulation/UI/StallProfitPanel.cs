using UnityEngine;
using StallSpace;
using Progress;

namespace DaySimulation.UI
{
    public class StallProfitPanel : MonoBehaviour
    {
        /// <summary>
        /// The stall profit object to be placed on the stall profit panel.
        /// </summary>
        public GameObject StallProfitObject;

        /// <summary>
        /// The text which displays the total profit.
        /// </summary>
        public GameObject TotalProfitTextObject;

        /// <summary>
        /// Amount of frame interval between displaying the stall profits.
        /// </summary>
        public int StallProfitDisplayInterval;

        /// <summary>
        /// Keeps track of the number of frames that has elapsed.
        /// </summary>
        private int timer;

        /// <summary>
        /// The current stall index whose profits are to be displayed.
        /// </summary>
        private int currentStallToDisplay = 0;

        /// <summary>
        /// The maximum number of stalls.
        /// </summary>
        private int MaxStallCount;

        // Use this for initialization
        void Start()
        {
            MaxStallCount = ProgressManager.StallSpaces.Length;
        }

        // Update is called once per frame
        void Update()
        {
            if (timer >= StallProfitDisplayInterval)
            {
                // Keep filling the stall profit dislay grid.
                if (currentStallToDisplay < MaxStallCount)
                {
                    if (ProgressManager.StallSpaces[currentStallToDisplay] == null)
                    {
                        return;
                    }

                    if (ProgressManager.StallSpaces[currentStallToDisplay].SpaceType != StallSpaceType.EmptyStall)
                    {
                        GameObject stallProfitObject = Instantiate(StallProfitObject, transform);

                        // Set the values of the stall profit display.
                        stallProfitObject.GetComponent<StallProfit>().SetValues(ProgressManager.StallSpaces[currentStallToDisplay].SpaceType, ProfitTracker.instance.StallProfit[currentStallToDisplay]);

                        // Increase the total profit.
                        TotalProfitTextObject.GetComponent<TotalProfitText>().TotalProfit += ProfitTracker.instance.StallProfit[currentStallToDisplay];

                        timer = 0;
                    }

                    currentStallToDisplay++;
                }
            }

            timer++;
        }
    }
}