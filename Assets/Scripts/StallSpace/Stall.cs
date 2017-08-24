using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PreparationSceneUI;
using Progress;

namespace StallSpace
{
    public class Stall : StallSpace
    {
        #region Stall Properties
        /// <summary>
        /// The amount of stock the stall has.
        /// </summary>
        public new int StockCount
        {
            get
            {
                return stockCount;
            }
            set
            {
                stockCount = value;
                ProgressManager.StallSpaces[StallSpaceNumber].StockCount = StockCount;
                SetStockCountDisplay(stockCount);
            }
        }
        private int stockCount;

        /// <summary>
        /// The maximum number of customers that can be in the line.
        /// </summary>
        public int MaxCustomersInLine = 3;
        /// <summary>
        /// The current number of customer in line.
        /// </summary>
        private int customersInLine = 0;
        /// <summary>
        /// The number of customer currently in line is read-only to other objects that interact.
        /// </summary>
        public int CustomersInLine
        {
            get
            {
                return customersInLine;
            }
        }

        /// <summary>
        /// The percentage of the stall's probability to attract a customer.
        /// </summary>
        public int AttractionPercentage = 50;
        /// <summary>
        /// Time it takes to serve the customer.
        /// </summary>
        public int ServingTime = 270;
        #endregion

        #region Current Stall Values
        /// <summary>
        /// The current amount the stall has spent serving.
        /// </summary>
        private int currentServeTime;
        /// <summary>
        /// The current serve time is read-only to other objects that interact.
        /// </summary>
        public int CurrentServeTime
        {
            get
            {
                return currentServeTime;
            }
        }
        #endregion
        
        /// <summary>
        /// The object that displays the stock count.
        /// </summary>
        public GameObject StockCountDisplay;
        /// <summary>
        /// Stores the instance of the stok count display.
        /// </summary>
        private GameObject stockCountDisplay;

        /// <summary>
        /// Initialization of the stall.
        /// </summary>
        void Start()
        {
            // Set the stock count display.
            StockCountDisplay.transform.position = new Vector3(transform.GetComponent<RectTransform>().rect.size.x / 2 + 0.3f, transform.GetComponent<RectTransform>().rect.size.y / 2 - 1f, 0);
            stockCountDisplay = Instantiate(StockCountDisplay, gameObject.transform);
            SetStockCountDisplay(stockCount);
        }

        /// <summary>
        /// Sets the displayed stock count on the stock count display.
        /// </summary>
        /// <param name="stockCount">The stock count to be displayed.</param>
        private void SetStockCountDisplay(int stockCount)
        {
            if (stockCountDisplay != null)
            {
                stockCountDisplay.GetComponent<StallStockDisplay>().SetStockCount(stockCount);
            }
        }

        /// <summary>
        /// Called when a customer buys from the stall.
        /// </summary>
        public void Buy(int amount)
        {
            StockCount--;
            ProgressManager.StallSpaces[StallSpaceNumber].StockCount = StockCount;
        }

        /// <summary>
        /// Adds a customer to the line.
        /// </summary>
        public void AddACustomerToLine()
        {
            customersInLine++;
        }

        /// <summary>
        /// Removes a customer from the line.
        /// </summary>
        public void RemoveACustomerFromLine()
        {
            if (CustomersInLine > 0)
            {
                customersInLine--;
            }
        }

        /// <summary>
        /// Increments the stall's current serve time.
        /// </summary>
        public void IncrementServeTime()
        {
            currentServeTime++;
        }

        /// <summary>
        /// Resets the stall's current serve time.
        /// </summary>
        public void ResetServeTime()
        {
            currentServeTime = 0;
        }
    }
}