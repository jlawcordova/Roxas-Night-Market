using System;
using System.Collections.Generic;
using UnityEngine;
using Progress;
using StallSpace.Upgrades;

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
        public bool ShowEmptyStalls = true;
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
        /// <summary>
        /// Used to instantiate isaw stalls.
        /// </summary>
        public GameObject IsawStallPrefab;
        /// <summary>
        /// Used to instantiate icecream stalls.
        /// </summary>
        public GameObject IcecreamStallPrefab;
        /// <summary>
        /// Used to instantiate fruitshake stalls.
        /// </summary>
        public GameObject FruitShakeStallPrefab;
        /// <summary>
        /// Used to instantiate fountains.
        /// </summary>
        public GameObject FountainPrefab;
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
                if (stallSpace == null)
                {
                    continue;
                }
                // Temporary gameobject variable.
                GameObject stall;

                // Create stall space content based on the progress.
                switch (stallSpace.SpaceType)
                {
                    case StallSpaceType.EmptyStall:
                        #region Create Empty Stall Space
                        if (ShowEmptyStalls)
                        {
                            stall = Instantiate(EmptyStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 1.5f, 0), Quaternion.identity);
                            stall.GetComponent<StallSpace>().StallSpaceNumber = stallSpace.StallSpaceNumber;
                        }

                        break;
                    #endregion

                    case StallSpaceType.KwekKwekStall:
                        #region Create KwekKwek Stall
                        stall = Instantiate(KwekKwekStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);

                        // Set the stall values.
                        SetStallValues(stall, stallSpace);
                        #endregion

                        break;
                    case StallSpaceType.IsawStall:
                        #region Create IsawStall Stall
                        stall = Instantiate(IsawStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);

                        // Set the stall values.
                        SetStallValues(stall, stallSpace);
                        #endregion

                        break;
                    case StallSpaceType.IcecreamStall:
                        #region Create IcecreamStall Stall
                        stall = Instantiate(IcecreamStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);
    
                        // Set the stall values.
                        SetStallValues(stall, stallSpace);
                        #endregion

                        break;
                    case StallSpaceType.FruitShakeStall:
                        #region Create IcecreamStall Stall
                        stall = Instantiate(FruitShakeStallPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);

                        // Set the stall values.
                        SetStallValues(stall, stallSpace);
                        #endregion

                        break;
                    case StallSpaceType.Fountain:
                        #region Create IcecreamStall Stall
                        stall = Instantiate(FountainPrefab, new Vector3(((stallSpace.StallSpaceNumber - 1) * StallSpaceIntervals), 2, 0), Quaternion.identity);

                        // Set the stall values.
                        SetStallValues(stall, stallSpace);
                        #endregion

                        break;
                    default:
                        throw new ArgumentException("Invalid stall space type.");
                }
            }
        }


        /// <summary>
        /// Sets the values of a stall based on the stall space information.
        /// </summary>
        /// <param name="stall">The stall gameobject.</param>
        /// <param name="stallSpace">The stall space information.</param>
        void SetStallValues(GameObject stall, StallSpaceInformation stallSpace)
        {
            stall.GetComponent<StallSpace>().SpaceType = stallSpace.SpaceType;
            stall.GetComponent<StallSpace>().StallSpaceNumber = stallSpace.StallSpaceNumber;
            stall.GetComponent<Stall>().StockCount = stallSpace.StockCount;
            if (stallSpace.StallUpgrades != null)
            {
                stall.GetComponent<StallSpace>().StallUpgrades = new List<UpgradeData>(stallSpace.StallUpgrades);
            }
        }
    }
}   