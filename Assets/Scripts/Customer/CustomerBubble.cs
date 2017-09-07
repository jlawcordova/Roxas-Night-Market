using UnityEngine;

namespace Customer
{
    /// <summary>
    /// The customer bubble script which allows the bubble to move with the customer.
    /// </summary>
    public class CustomerBubble : MonoBehaviour
    {
        #region Movement Properties
        /// <summary>
        /// The amount of time the customer bubble appears.
        /// </summary>
        public int AppearanceTime = 50;
        /// <summary>
        /// The speed to which the customer bubble offsets upwards.
        /// </summary>
        public float Speed = 0.005f;
        #endregion

        #region Customer using the Bubble Properties
        /// <summary>
        /// The customer to which this customer bubble is attached.
        /// </summary>
        [HideInInspector]
        public GameObject CustomerUsingTheBubble;
        /// <summary>
        /// The direction of the bubble with respect to the customer.
        /// </summary>
        public Vector3 BubbleDirection;
        #endregion

        #region Current Bubble Values
        /// <summary>
        /// The current amount of time that the customer bubble has appeared.
        /// </summary>
        private int currentAppearanceTime = 0;
        /// <summary>
        /// The vector indicating the current amount of offset the bubble appears.
        /// </summary>
        private Vector3 animationOffset = new Vector3(0, 0, 0);
        #endregion

        /// <summary>
        /// The customer component of the customer using the bubble object.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// During the initialization of the customer bubble.
        /// </summary>
        void Start()
        {
            // Get the customer component of the customer game object.
            customer = CustomerUsingTheBubble.GetComponent<Customer>();
        }

        /// <summary>
        /// Called once every Delta time.
        /// </summary>
        void FixedUpdate()
        {
            // Keep animating the customer bubble until its time limit.
            if (currentAppearanceTime < AppearanceTime)
            {
                currentAppearanceTime++;

                // Offset the bubble for its animation.
                animationOffset += new Vector3(0, Speed, 0);

                // Get the amount of offset made with respect to the customer position.
                Vector3 customerOffset = new Vector3(customer.CustomerBubbleOffset.x * BubbleDirection.x, customer.CustomerBubbleOffset.y, customer.CustomerBubbleOffset.z);

                // Move the bubble depending on its customer's position.
                transform.position = CustomerUsingTheBubble.transform.position + customerOffset + animationOffset;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

