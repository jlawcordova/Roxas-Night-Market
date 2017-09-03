using UnityEngine;
using StallSpace.Upgrades;
using Progress;

namespace StallSpace
{
    /// <summary>
    /// Represents a stall which sells products to customers.
    /// </summary>
    public class Stall : StallSpace
    {
        #region Stall Properties
        /// <summary>
        /// The maximum amount of stock the stall can have.
        /// </summary>
        public int MaxStockCount;
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
        public int MaxCustomersInLine;
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
        private int customersInLine = 0;

        /// <summary>
        /// The percentage of the stall's probability to attract a customer.
        /// </summary>
        public int AttractionPercentage;
        /// <summary>
        /// Time it takes to serve the customer.
        /// </summary>
        public int ServingTime;
        /// <summary>
        /// The cost to restock this stall.
        /// </summary>
        public int StallRestockCost;
        /// <summary>
        /// The The amount of money earned by the stall per customer purchase.
        /// </summary>
        public int StallProductPurchaseCost;
        #endregion

        #region Stall Upgrade Objects
        /// <summary>
        /// All objects that can be added to the stall as upgrades.
        /// </summary>
        public GameObject[] StallUpgradeObjects;
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

        #region Stock Count Display Properties
        /// <summary>
        /// The object that displays the stock count.
        /// </summary>
        public GameObject StockCountDisplay;
        /// <summary>
        /// Stores the instance of the stok count display.
        /// </summary>
        private GameObject stockCountDisplay;

        /// <summary>
        /// The X offset of the stock count display from the stall's center.
        /// </summary>
        private float StockCountDisplayXOffset = 0.3f;
        /// <summary>
        /// The Y offset of the stock count display from the stall's center.
        /// </summary>
        private float StockCountDisplayyOffset = -1f;
        #endregion

        /// <summary>
        /// Initialization of the stall.
        /// </summary>
        void Start()
        {
            // Set the stock count display.
            StockCountDisplay.transform.position = new Vector3(transform.GetComponent<RectTransform>().rect.size.x / 2 + StockCountDisplayXOffset, 
                transform.GetComponent<RectTransform>().rect.size.y / 2 + StockCountDisplayyOffset, 
                0);

            stockCountDisplay = Instantiate(StockCountDisplay, gameObject.transform);
            SetStockCountDisplay(stockCount);
            
            // Add all upgrades.
            if (StallUpgrades != null)
            {
                foreach (int stallUpgrade in StallUpgrades)
                {
                    if (stallUpgrade < StallUpgradeObjects.Length)
                    {
                        if (StallUpgradeObjects[stallUpgrade] != null)
                        {
                            Instantiate(StallUpgradeObjects[stallUpgrade], transform);
                            StallUpgradeObjects[stallUpgrade].GetComponent<Upgrade>().TakeEffect(this);
                        }
                    }
                }
            }
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

            // Update progress.
            ProgressManager.StallSpaces[StallSpaceNumber].StockCount = StockCount;
            ProgressManager.Money += StallProductPurchaseCost;
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