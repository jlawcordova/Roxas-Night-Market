using UnityEngine;
using DaySimulation;
using Progress;
using StallSpace;
using StallSpace.Upgrades;

namespace Customer
{
    /// <summary>
    /// The customer generator script instantiates customers at random locations.
    /// </summary>
    public class CustomerGenerator : MonoBehaviour
    {
        #region Generator Properties
        /// <summary>
        /// The customers object that will be generated.
        /// </summary>
        public GameObject[] Customers;
        /// <summary>
        /// The X position of the customer when instantiated on the left.
        /// </summary>
        public float CustomerLeftInstatiationPosition;
        /// <summary>
        /// The X position of the customer when instantiated on the right.
        /// </summary>
        public float CustomerRightInstatiationPosition;
        /// <summary>
        /// Possible Y positions that the customer can have when instantiated.
        /// </summary>
        public float[] CustomerYInstantiation;
        /// <summary>
        /// The amount of interval between instantiating another customer.
        /// </summary>
        public int CustomerInstantiationInterval;
        /// <summary>
        /// xx/100 chance to generate a customer per customer instantiation interval.
        /// </summary>
        public int GeneratingChance;

        /// <summary>
        /// The X position of the customer on the left where it gets destroyed.
        /// </summary>
        public float CustomerLeftEndPosition;
        /// <summary>
        /// The X position of the customer on the right where it gets destroyed.
        /// </summary>
        public float CustomerRightEndPosition;

        /// <summary>
        /// The hour on the clock object to stop generating customers.
        /// </summary>
        public int StopGeneratingHour;
        /// <summary>
        /// The minute on the clock object to stop generating customers.
        /// </summary>
        public int StopGeneratingMinute;
        #endregion

        #region CurrentGenerator Values
        /// <summary>
        /// An internal timer for detecting the amount of time that has passed.
        /// Used for determining if it is time to generate another customer.
        /// </summary>
        private int timer = 0;
        /// <summary>
        /// Flag for determining if the generator should continue to generate customers.
        /// </summary>
        private bool runGenerator = true;
        #endregion

        /// <summary>
        /// Initialization of the customer generator.
        /// </summary>
        void Start()
        {
            // TODO Refactor this. Make the fountain script more loosely coupled from this script.
            const int fountainCustomerIncrease = 15;
            const int sampaguitaCustomerIncrease = 5;

            foreach (StallSpaceInformation stallSpace in ProgressManager.StallSpaces)
            {
                if (stallSpace != null)
                {
                    if (stallSpace.SpaceType == StallSpaceType.Fountain)
                    {
                        GeneratingChance += fountainCustomerIncrease;
                        // TODO Refactor to loosely couple fountain upgrades from this script.
                        if (stallSpace.StallUpgrades != null)
                        {
                            foreach (UpgradeData upgradeData in stallSpace.StallUpgrades)
                            {
                                const int SampaguitaUpgrade = 1;
                                if (upgradeData.UpgradeNumber == SampaguitaUpgrade)
                                {
                                    GeneratingChance += sampaguitaCustomerIncrease;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called once every Delta time.
        /// </summary>
        void FixedUpdate()
        {
            // Check if it is time to stop generating customers.
            if (Clock.CurrentHour == StopGeneratingHour && Clock.CurrentMinute == StopGeneratingMinute)
            {
                runGenerator = false;
            }

            // Continue to generate while allowed to do so.
            if (runGenerator)
            {
                if (timer >= CustomerInstantiationInterval)
                {
                    // Generate a customer when the chance is hit.
                    if (Random.Range(0, 100) < GeneratingChance)
                    {
                        int randomUnlockedNumber = Random.Range(0, ProgressManager.CustomersUnlocked.Count);
                        int customerNumber = ProgressManager.CustomersUnlocked[randomUnlockedNumber];

                        // 50/50 chance to place the customer either on the left or right.
                        if (Random.Range(0, 2) == 0)
                        {
                            Customers[customerNumber].GetComponent<Customer>().IsGoingRight = true;
                            Customers[customerNumber].GetComponent<Customer>().EndPoint = (CustomerRightEndPosition * (ProgressManager.PlaceSize + 1)) + (ProgressManager.PlaceSize * 2);
                        }
                        else
                        {
                            Customers[customerNumber].GetComponent<Customer>().IsGoingRight = false;
                            Customers[customerNumber].GetComponent<Customer>().EndPoint = CustomerLeftEndPosition;
                        }

                        // Instantiate the customer to its proper position.
                        Vector3 customerPosition = new Vector3(
                            Customers[customerNumber].GetComponent<Customer>().IsGoingRight ? CustomerLeftInstatiationPosition : (CustomerRightInstatiationPosition * (ProgressManager.PlaceSize + 1)) + (ProgressManager.PlaceSize * 2),
                            CustomerYInstantiation[Random.Range(0, CustomerYInstantiation.Length)], 
                            0);
                        
                        Instantiate(Customers[customerNumber], customerPosition, Quaternion.identity);
                    }
                    
                    // Reset instantiation timer after instantiating a customer.
                    timer = 0;
                }

                timer++;
            }
        }
    }
}

