using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaySimulation
{
    /// <summary>
    /// The stall script allows the stall to have its properties and allows the customer to interact with it.
    /// </summary>
    public class Stall : MonoBehaviour
    {

        #region Stall Properties
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
        /// Called when a customer buys from the stall.
        /// </summary>
        public void Buy(int amount)
        {
            // Update the number of customers served on the UI.
            UIManager.instance.CustomerServed += amount;
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

