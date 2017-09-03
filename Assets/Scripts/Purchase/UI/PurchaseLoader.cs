using UnityEngine;
using UnityEngine.UI;

namespace Purchase.UI
{
    /// <summary>
    /// Loads all purchase items on the selection grid.
    /// </summary>
    public class PurchaseLoader : MonoBehaviour
    {
        /// <summary>
        /// All buy stall items.
        /// </summary>
        public GameObject[] BuyStallItems;

        /// <summary>
        /// All kwekkwek stall upgrade items.
        /// </summary>
        public GameObject[] UpgradeKwekkwekStallItems;

        /// <summary>
        /// The heading text of the purchase UI.
        /// </summary>
        public Text HeadingText;

        /// <summary>
        /// The selection grid which shows the purchase items.
        /// </summary>
        public GameObject PurchaseSelectionGrid;

        /// <summary>
        /// Initialization of the PurchaseScene loader.
        /// </summary>
        void Start()
        {
            switch (PurchaseInformation.Type)
            {
                case PurchaseType.BuyStall:
                    HeadingText.text = "Purchase A Stall";

                    // Add all buy stall items to the grid.
                    foreach (GameObject buyStallItem in BuyStallItems)
                    {
                        Instantiate(buyStallItem, PurchaseSelectionGrid.transform);
                    }

                    break;

                case PurchaseType.UpgradeKwekkwekStall:
                    HeadingText.text = "Purchase An Upgrade";

                    // Add all kwekkwek stall u[grades to the grid.
                    foreach (GameObject upgradeKwekkwekStallItem in UpgradeKwekkwekStallItems)
                    {
                        Instantiate(upgradeKwekkwekStallItem, PurchaseSelectionGrid.transform);
                    }

                    break;

                default:
                    break;
            }
        }
    }
}