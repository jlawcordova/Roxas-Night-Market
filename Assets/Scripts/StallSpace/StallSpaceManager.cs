using System;
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
        [HideInInspector]
        public static StallSpaceManager instance;

        #region Stall Manager Properties
        /// <summary>
        /// The amount of X intervals of the stalls.
        /// </summary>
        public float StallSpaceIntervals;
        #endregion

        #region Stall Prefabs
        /// <summary>
        /// Used to instantiate empty stalls.
        /// </summary>
        public GameObject EmptyStallPrefab;
        /// <summary>
        /// Used to instantiate kwekkwek stalls.
        /// </summary>
        public GameObject KwekKwekStallPrefab;
        #endregion

        /// <summary>
        /// Awakening of the stall manager.
        /// </summary>
        void Awake()
        {
            // Only one stall manager can exist.
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Initialization of the stall space manager.
        /// </summary>
        void Start()
        {
            // Create the stalls based on the progress.
            foreach (StallSpaceInformation stallSpace in ProgressManager.StallSpaces)
            {
                // Temporary gameobject variable.
                GameObject stall;

                // Create stall space content based on the progress.
                switch (stallSpace.SpaceType)
                {
                    case StallSpaceType.EmptyStall:
                        #region Create Empty Stall Space
                        stall = Instantiate(EmptyStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 0, 0), Quaternion.identity);
                        stall.GetComponent<StallSpace>().StallSpaceNumber = stallSpace.StallSpaceNumber;

                        break;
                        #endregion

                    case StallSpaceType.Stall:
                        #region Create Stall
                        stall = Instantiate(KwekKwekStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);
                        stall.GetComponent<StallSpace>().StallSpaceNumber = stallSpace.StallSpaceNumber;
                        stall.GetComponent<Stall>().StockCount = stallSpace.StockCount;
                        #endregion
                        
                        break;
                    default:
                        throw new ArgumentException("Invalid stall space type.");
                }
            }
        }
    }
}   