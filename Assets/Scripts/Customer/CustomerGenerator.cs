using UnityEngine;
using DaySimulation;

namespace Customer
{
    /// <summary>
    /// The customer generator script instantiates customers at random locations.
    /// </summary>
    public class CustomerGenerator : MonoBehaviour
    {
        #region Generator Properties
        /// <summary>
        /// The customer object that will be generated.
        /// </summary>
        public GameObject Customer;
        /// <summary>
        /// The amount of interval between instantiating another customer.
        /// </summary>
        public int CustomerInstantiationInterval = 30;
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
                // TODO Implement better customer generating algorithm.
                if (timer >= CustomerInstantiationInterval)
                {
                    if (Random.Range(0, 100) <= 100)
                    {
                        int test = Random.Range(0, 2);
                        if (test == 0)
                        {
                            Customer.GetComponent<Customer>().IsGoingRight = true;
                            Customer.GetComponent<Customer>().EndPoint = 9;
                        }
                        else
                        {
                            Customer.GetComponent<Customer>().IsGoingRight = false;
                            Customer.GetComponent<Customer>().EndPoint = -9;
                        }
                        Instantiate(Customer, new Vector3(Customer.GetComponent<Customer>().IsGoingRight ? -9 : 9, Random.Range(-4, -2)), Quaternion.identity);
                    }
                    timer = 0;
                }

                timer++;
            }
        }
    }
}

