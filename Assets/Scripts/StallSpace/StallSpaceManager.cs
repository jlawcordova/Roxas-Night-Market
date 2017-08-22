using UnityEngine;
using Progress;

namespace StallSpace
{
    /// <summary>
    /// Manages the creating of stalls in the game.
    /// </summary>
    public class StallSpaceManager : MonoBehaviour
    {
        /// <summary>
        /// The stall space manager singleton instance.
        /// </summary>
        public static StallSpaceManager instance;

        /// <summary>
        /// Used to instantiate empty stalls.
        /// </summary>
        public GameObject EmptyStallPrefab;
        /// <summary>
        /// Used to instantiate kwekkwek stalls.
        /// </summary>
        public GameObject KwekKwekStallPrefab;

        /// <summary>
        /// Initialization of the stall space manager.
        /// </summary>
        void Start()
        {
            // The stall space manager is a singleton.
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            // Create the stalls based on the progress.
            foreach (StallSpaceInformation stallSpace in ProgressManager.StallSpaces)
            {
                switch (stallSpace.SpaceType)
                {
                    case StallSpaceType.EmptyStall:
                        Instantiate(EmptyStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * 4), 0, 0), Quaternion.identity);

                        break;
                    case StallSpaceType.Stall:
                        GameObject stall = Instantiate(KwekKwekStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * 4), 2, 0), Quaternion.identity);
                        stall.GetComponent<Stall>().StallSpaceNumber = stallSpace.StallSpaceNumber;
                        stall.GetComponent<Stall>().StockCount = stallSpace.StockCount;

                        break;
                    default:
                        break;
                }
            }
        }
    }
}   