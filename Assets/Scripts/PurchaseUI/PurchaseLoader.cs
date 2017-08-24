using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurchaseUI
{
    public class PurchaseLoader : MonoBehaviour
    {
        /// <summary>
        /// All buy stall items.
        /// </summary>
        public GameObject[] BuyStallItems;
        
        /// <summary>
        /// The selection grid which shows the purchase items.
        /// </summary>
        public GameObject PurchaseSelectionGrid;

        /// <summary>
        /// Initialization of the PurchaseScene loader.
        /// </summary>
        void Start()
        {
            PurchaseInformation.Type = PurchaseType.BuyStall;

            switch (PurchaseInformation.Type)
            {
                case PurchaseType.BuyStall:
                    // Add all buy stall items to the grid.
                    foreach (GameObject buyStallItem in BuyStallItems)
                    {
                        Instantiate(buyStallItem, PurchaseSelectionGrid.transform);
                    }

                    break;
                default:
                    break;
            }
        }
    }
}