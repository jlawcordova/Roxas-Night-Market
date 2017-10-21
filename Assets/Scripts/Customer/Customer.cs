using System.Collections.Generic;
using UnityEngine;
using StallSpace;
using Audio;

namespace Customer
{
    /// <summary>
    /// The Customer script which allows the Customer object to move autonomously.
    /// </summary>
    public class Customer : MonoBehaviour
    {
        #region Movement Properties
        /// <summary>
        /// The speed of the customer.
        /// </summary>
        public float Speed = 0.05f;
        /// <summary>
        /// Indicates whether the customer is walking right or left.
        /// </summary>
        [HideInInspector]
        public bool IsGoingRight;
        /// <summary>
        /// Point where customer stops and is destroyed.
        /// </summary>
        [HideInInspector]
        public float EndPoint;

        /// <summary>
        /// The animator of the customer.
        /// </summary>
        private Animator animator;
        #endregion

        #region Interacting Layers Properties
        /// <summary>
        /// The layer mask of the stalls.
        /// </summary>
        public LayerMask StallLayer;
        /// <summary>
        /// The layer mask of the customers.
        /// </summary>
        public LayerMask CustomerLayer;
        #endregion

        #region Usable Components Properties
        /// <summary>
        /// Used to store this game object's box collider.
        /// </summary>
        private BoxCollider2D boxCollider;
        #endregion

        #region Customer Properties
        /// <summary>
        /// The amount of patience the customer has left.
        /// </summary>
        public int CustomerPatience = 390;
        /// <summary>
        /// 1/x chance the customer will perform a special move.
        /// </summary>
        public int CustomerSpecialChance = 1750;
        /// <summary>
        /// The amount of extra that the customer pays a stall.
        /// </summary>
        public int ExtraPayment;
        public bool IsAttractedToEverything;
        public StallSpaceType[] HatedStallTypes;
        #endregion

        #region Current Customer Values
        /// <summary>
        /// The current state of the customer.
        /// </summary>
        private CustomerState customerStatus = CustomerState.Walking;
        /// <summary>
        /// The customer status is read-only for other objects that interact.
        /// </summary>
        public CustomerState CustomerStatus
        {
            get
            {
                return customerStatus;
            }
        }
        /// <summary>
        /// The stall where the customer is currently buying.
        /// </summary>
        private Stall currentStall = null;
        /// <summary>
        /// The list of stalls the customer has already seen.
        /// </summary>
        private List<Stall> seenStalls = new List<Stall>();
        /// <summary>
        /// The current amount of patience remaining on the customer.
        /// </summary>
        private int currentCustomerPatience = 0;
        /// <summary>
        /// The position the customer will go to after buying from a stall.
        /// </summary>
        private Vector3 positionAfterBuying;
        /// <summary>
        /// The position the customer will go to after walking away from the stall.
        /// </summary>
        private Vector3 positionToReturn;
        #endregion

        #region Customer Bubbles
        /// <summary>
        /// The offset to where the customer bubble will appear on the left.
        /// </summary>
        public Vector3 CustomerBubbleOffset;

        /// <summary>
        /// The customer bubble object for buying kwekkwek.
        /// </summary>
        public GameObject CustomerKwekKwekBubble;

        /// <summary>
        /// The customer bubble object for buying isaw.
        /// </summary>
        public GameObject CustomeIsawBubble;

        /// <summary>
        /// The customer bubble object for buying icecream.
        /// </summary>
        public GameObject CustomerIcecreamBubble;

        /// <summary>
        /// The customer bubble object for buying fruit shake.
        /// </summary>
        public GameObject CustomerFruitShakeBubble;

        /// <summary>
        /// The customer bubble object for showing impatience.
        /// </summary>
        public GameObject CustomerTimeBubble;

        /// <summary>
        /// The customer bubbleobject for showing that the customer has bought from the stall and is happy.
        /// </summary>
        public GameObject CustomerHappyBubble;
        #endregion

        #region Customer Sounds
        /// <summary>
        /// The sound when the customer is buying.
        /// </summary>
        public AudioClip BuyingSound;
        /// <summary>
        /// The sound when the customer has already bought something.
        /// </summary>
        public AudioClip BoughtSound;
        /// <summary>
        /// The sound when the customer gets impatient.
        /// </summary>
        public AudioClip ImpatientSound;

        /// <summary>
        /// The audio source of the game object.
        /// </summary>
        private AudioSource soundSource;
        #endregion

        /// <summary>
        /// Initialization of the customer.
        /// </summary>
        void Start()
        {
            soundSource = gameObject.GetComponent<AudioSource>();
            animator = gameObject.GetComponent<Animator>();

            // Set the soound of this game object based on the settings.
            Sound.SetSound(soundSource, 0.5f);

            // Set the boxcollider.
            boxCollider = GetComponent<BoxCollider2D>();

            if (IsGoingRight)
            {
                transform.GetComponent<SpriteRenderer>().flipX = true;
            }

            // Set the customer's patience.
            currentCustomerPatience = CustomerPatience;
        }

        void PlaySound(AudioClip clip)
        {
            soundSource.clip = clip;

            soundSource.Play();
        }

        /// <summary>
        /// Called once every Delta time.
        /// </summary>
        void FixedUpdate()
        {
            // Keep the customer going until it reaches the endpoint.
            if ((IsGoingRight && gameObject.transform.position.x < EndPoint) ||
                (!IsGoingRight && gameObject.transform.position.x > EndPoint))
            {
                // Perform the necessary action depending on the customer state.
                switch (CustomerStatus)
                {
                    case CustomerState.Walking:
                        #region Walking Procedure
                        // Customer has a random chance to perform a special move.
                        if (Random.Range(0, CustomerSpecialChance) < 1)
                        {
                            animator.SetTrigger("IsSpecial");

                            break;
                        }

                        // Only allow the customer to walk when it is doing a special move.
                        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Special"))
                        {
                            // Keep the customer walking straight (depending on the direction), until attracted to a stall.
                            Walk(IsGoingRight ? Speed : Speed * -1, 0);
                        }
                       

                        // Raycast which contains the stall that is detected by the customer.
                        RaycastHit2D hit;
                        // If a stall exists above, determine if the customer will be attracted to the stall.
                        if (IsStallAbove(out hit))
                        {
                            // Get the stall detected above.
                            currentStall = hit.transform.GetComponent<Stall>();

                            // If it has already been seen, do not attempt to attract.
                            // Try to attract otherwise.
                            if (!seenStalls.Contains(currentStall))
                            {
                                // Add the stall to the list of stalls already seen by the customer.
                                seenStalls.Add(currentStall);

                                if ((IsAttractedToStall(currentStall) || IsAttractedToEverything) && currentStall.gameObject.GetComponent<StallSpace.Stall>().StockCount > 0)
                                {
                                    // Only try to attract the customer when the stall line is not yet full.
                                    if (currentStall.CustomersInLine + 1 <= currentStall.MaxCustomersInLine)
                                    {
                                        currentStall.AddACustomerToLine();
                                        // If attracted, set the customer to walk to the stall.
                                        currentCustomerPatience += currentStall.PatienceIncrease;

                                        customerStatus = CustomerState.WalkingToStall;
                                        animator.SetTrigger("IsWalkingUp");

                                        // Bring customer to the front of all other objects.
                                        transform.GetComponent<SpriteRenderer>().sortingOrder += 1;
                                        // Set the customer who is walking behind to be in the upmost layer.
                                        SetCustomerBehindToUpperLayer();
                                        // Save the position where the customer will return to after buying.
                                        positionToReturn = transform.position;
                                    }
                                }
                            }
                        }

                        break;
                    #endregion

                    case CustomerState.WalkingToStall:
                        #region Walk to Stall Procedure
                        // Set the customer who is walking behind to be in the upmost layer.
                        SetCustomerBehindToUpperLayer();

                        if (currentStall.GetComponent<StallSpace.Stall>().StockCount <= 0)
                        {
                            customerStatus = CustomerState.WalkingAwayFromStall;
                            animator.SetTrigger("IsWalkingDown");

                            break;
                        }

                        // Keep walking to the stall if there are no customers in line.
                        if (!IsOtherCustomerInFrontBuying())
                        {
                            Walk(0, Speed);

                            // Check if the customer has reached the stall, then the customer can start buying.
                            if (HasReachedStall())
                            {
                                // Reset customer's patience.
                                currentCustomerPatience = CustomerPatience;

                                // When stall is reached, set the customer to buy from the stall.
                                customerStatus = CustomerState.BuyingFromStall;
                                animator.SetTrigger("IsIdle");

                                // Play buying sound.
                                PlaySound(BuyingSound);

                                // Generate different bubble depending on stall type.
                                switch (currentStall.SpaceType)
                                {
                                    case StallSpaceType.EmptyStall:
                                        break;
                                    case StallSpaceType.KwekKwekStall:
                                        GenerateBubble(CustomerBubbleType.Kwekkwek);
                                        break;
                                    case StallSpaceType.IsawStall:
                                        GenerateBubble(CustomerBubbleType.Isaw);
                                        break;
                                    case StallSpaceType.IcecreamStall:
                                        GenerateBubble(CustomerBubbleType.Icecream);
                                        break;
                                    case StallSpaceType.FruitShakeStall:
                                        GenerateBubble(CustomerBubbleType.FruitShake);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            //Wait in line if there are other customers
                            customerStatus = CustomerState.WaitingInLine;
                            animator.SetTrigger("IsIdle");
                            break;
                        }

                        break;
                    #endregion
                        
                    case CustomerState.WaitingInLine:
                        #region Waiting in Line Procedure
                        if (currentStall.GetComponent<StallSpace.Stall>().StockCount <= 0)
                        {
                            customerStatus = CustomerState.WalkingAwayFromStall;
                            animator.SetTrigger("IsWalkingDown");

                            break;
                        }

                        // If there are no more customers in front, walk to the stall.
                        if (!IsOtherCustomerInFrontBuying())
                        {
                            customerStatus = CustomerState.WalkingToStall;
                            animator.SetTrigger("IsWalkingUp");
                            break;
                        }
                        // If customer lost all patience, make customer leave.
                        if (currentCustomerPatience <= 0)
                        {
                            PlaySound(ImpatientSound);
                            
                            GenerateBubble(CustomerBubbleType.Time);
                            customerStatus = CustomerState.WalkingAwayFromStall;
                            animator.SetTrigger("IsWalkingDown");

                            currentStall.RemoveACustomerFromLine();

                            currentCustomerPatience = CustomerPatience;
                            break;
                        }

                        // Keep losing patience while waiting in line.
                        currentCustomerPatience--;

                        break;
                        #endregion
                        
                    case CustomerState.BuyingFromStall:
                        #region Buying from Stall Procedure
                        // If customer lost all patience, make customer leave.
                        if (currentCustomerPatience <= 0)
                        {
                            PlaySound(ImpatientSound);

                            GenerateBubble(CustomerBubbleType.Time);
                            customerStatus = CustomerState.WalkingAwayFromStall;
                            animator.SetTrigger("IsWalkingDown");

                            currentStall.RemoveACustomerFromLine();

                            // Reset patience time.
                            currentCustomerPatience = CustomerPatience;

                            break;
                        }
                        // Check if stall has already finished serving.
                        if (currentStall.CurrentServeTime >= currentStall.ServingTime)
                        {
                            PlaySound(BoughtSound);
                            GenerateBubble(CustomerBubbleType.Happy);
                            customerStatus = CustomerState.BoughtFromStall;
                            animator.SetTrigger("IsWalking");
                            if (!IsGoingRight)
                            {
                                transform.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                            }

                            currentStall.Buy(1, ExtraPayment);

                            // Get the position where the customer will walk to after buying.
                            positionAfterBuying = transform.position + new Vector3(1, 0, 0);

                            // Reset stall serve time.
                            currentStall.ResetServeTime();
                            // Reset customer patience.
                            currentCustomerPatience = CustomerPatience;

                            break;
                        }

                        // Customer keeps losing patience until stall has finished preparing and serving.
                        currentCustomerPatience--;
                        currentStall.IncrementServeTime();

                        break;
                    #endregion
                        
                    case CustomerState.BoughtFromStall:
                        #region Bought from Stall Procedure
                        // Make the customer walk to a position on the right after buying.
                        Walk(Speed, 0);
                        if (transform.position.x >= positionAfterBuying.x)
                        {
                            customerStatus = CustomerState.WalkingAwayFromStall;
                            animator.SetTrigger("IsWalkingDown");
                            if (!IsGoingRight)
                            {
                                transform.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                            }

                            // Remove the customer from the stall's line after buying.
                            currentStall.RemoveACustomerFromLine();
                            break;
                        }

                        break;
                        #endregion
                        
                    case CustomerState.WalkingAwayFromStall:
                        #region Walking Away from Stall Procedure
                        // Make the customer walk away from the stall until it reaches the original position on the street.
                        Walk(0, -Speed);
                        if (transform.position.y <= positionToReturn.y)
                        {
                            // Make the customer walk normally again upon reaching the street.
                            customerStatus = CustomerState.Walking;
                            animator.SetTrigger("IsWalking");
                        }

                        break;
                    #endregion

                    default:
                        throw new System.ArgumentException("Customer state invalid.");
                }
            }
            else
            {
                // Destory customer once it reaches the endpoint.
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Walks the customer in a certain direction.
        /// </summary>
        private void Walk(float x, float y)
        {
            transform.position += new Vector3(x, y, 0);
        }

        /// <summary>
        /// Checks if a stall exists above the customer.
        /// </summary>
        /// <param name="hit">An output parameter which is the stall that was hit.</param>
        /// <returns>True if a stall exists.</returns>
        private bool IsStallAbove(out RaycastHit2D hit)
        {
            hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(0, 10, 0), StallLayer);

            return (hit.transform != null);
        }

        /// <summary>
        /// Calculates if a customer is attracted to a stall.
        /// </summary>
        /// <param name="stall"></param>
        /// <returns></returns>
        private bool IsAttractedToStall(Stall stall)
        {
            foreach (StallSpaceType hatedType in HatedStallTypes)
            {
                if (stall.SpaceType == hatedType)
                {
                    return false;
                }
            }

            // Get random number of attraction.
            int attraction = Random.Range(0, 100);

            // Stall attracts customer if the attraction acquired is less than the attaction percentage of the stall.
            return (attraction <= stall.AttractionPercentage);
        }

        /// <summary>
        /// Checks if the customer has reached the stall.
        /// </summary>
        /// <returns>True if stall has been reached.</returns>
        private bool HasReachedStall()
        {
            return (Physics2D.Linecast(transform.position, transform.position, StallLayer));
        }

        /// <summary>
        /// Checks if there is another customer in front who is waiting in line or buying.
        /// </summary>
        /// <returns></returns>
        private bool IsOtherCustomerInFrontBuying()
        {
            // Disabled this gameobject's box collider so that it will not be included in the raycast.
            boxCollider.enabled = false;
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position + new Vector3(0, 0.51f, 0), transform.position + new Vector3(0, 0.52f, 0), CustomerLayer);
            // Reenable the box collider.
            boxCollider.enabled = true;

            // Check all the hit objects if any is another customer waiting in line.
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<Customer>().CustomerStatus == CustomerState.WaitingInLine || hit.transform.GetComponent<Customer>().CustomerStatus == CustomerState.BuyingFromStall)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Set the customer who is walking behind to be in the upmost layer.
        /// </summary>
        private void SetCustomerBehindToUpperLayer()
        {
            RaycastHit2D[] walkingToStallHits;
            // Get all customers behind who are walking to stall.
            if (IsOtherCustomerBehindWalkingToStall(out walkingToStallHits))
            {
                foreach (RaycastHit2D walkingToStallHit in walkingToStallHits)
                {
                    // Place them in the uppermost layer if they are not in a layer higher than this customer.
                    if (walkingToStallHit.transform.GetComponent<SpriteRenderer>().sortingOrder <= transform.GetComponent<SpriteRenderer>().sortingOrder)
                    {
                        walkingToStallHit.transform.GetComponent<SpriteRenderer>().sortingOrder++;
                    }
                }
            }
        }
         
        /// <summary>
        /// Checks if another customer is in front or at the back walking towards a stall.
        /// </summary>
        /// <param name="hits"></param>
        /// <returns></returns>
        private bool IsOtherCustomerBehindWalkingToStall(out RaycastHit2D[] hits)
        {
            // Disabled this gameobject's box collider so that it will not be included in the raycast.
            boxCollider.enabled = false;
            hits = Physics2D.LinecastAll(transform.position + new Vector3(0, -1.5f, 0), transform.position + new Vector3(0, -0.5f, 0), CustomerLayer);
            // Reenable the box collider.
            boxCollider.enabled = true;

            // Check all the hit objects if any is another customer walking to a stall.
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<Customer>().CustomerStatus == CustomerState.WalkingToStall)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Create a bubble to appear beside the customer.
        /// </summary>
        /// <param name="type"></param>
        private void GenerateBubble(CustomerBubbleType type)
        {
            // TODO Needs refactoring. A single function call can be made.
            switch (type)
            {
                case CustomerBubbleType.Happy:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomerHappyBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomerHappyBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomerHappyBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                case CustomerBubbleType.Time:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomerTimeBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomerTimeBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomerTimeBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                case CustomerBubbleType.Kwekkwek:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomerKwekKwekBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomerKwekKwekBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomerKwekKwekBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                case CustomerBubbleType.Isaw:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomeIsawBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomeIsawBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomeIsawBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                case CustomerBubbleType.Icecream:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomerIcecreamBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomerIcecreamBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomerIcecreamBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                case CustomerBubbleType.FruitShake:
                    // Set the bubbles customer to this game object as well as the direction.
                    CustomerFruitShakeBubble.GetComponent<CustomerBubble>().CustomerUsingTheBubble = gameObject;
                    Instantiate(CustomerFruitShakeBubble, transform.position + new Vector3(CustomerBubbleOffset.x * CustomerFruitShakeBubble.GetComponent<CustomerBubble>().BubbleDirection.x, CustomerBubbleOffset.y, CustomerBubbleOffset.z), Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}
