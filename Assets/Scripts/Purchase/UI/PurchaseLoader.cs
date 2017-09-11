using UnityEngine;
using UnityEngine.UI;
using Progress;
using StallSpace;
using StallSpace.Upgrades;

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
        /// All kwekkwek stall upgrade items.
        /// </summary>
        public GameObject[] UpgradeIsawStallItems;

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

                case PurchaseType.UpgradeStall:
                    HeadingText.text = "Purchase An Upgrade";

                    // Place all purchasable items depending on the stall type.
                    switch (ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].SpaceType)
                    {
                        case StallSpaceType.EmptyStall:
                            throw new System.ArgumentException("Empty stall space has no upgrades.");
                        case StallSpaceType.KwekKwekStall:
                            FillWithUpgrades(UpgradeKwekkwekStallItems);

                            break;
                        case StallSpaceType.IsawStall:
                            FillWithUpgrades(UpgradeIsawStallItems);

                            break;
                        default:
                            throw new System.ArgumentException("Invalid stall type");
                    }
                    // Add all kwekkwek stall upgrades to the grid.
                    

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Fills the purchase selection grid with upgrade items.
        /// </summary>
        /// <param name="upgradeItems"></param>
        private void FillWithUpgrades(GameObject[] upgradeItems)
        {
            foreach (GameObject upgradeItem in upgradeItems)
            {
                int upgradeNumber = upgradeItem.GetComponent<UpgradePurchaseItemPanel>().UpgradeNumber;
                bool purchased = false;

                // Check if upgrade has already been purchased.
                if (ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades != null)
                {
                    foreach (UpgradeData upgrade in ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].StallUpgrades)
                    {
                        if (upgrade.UpgradeNumber == upgradeNumber)
                        {
                            purchased = true;
                            break;
                        }
                    }
                }

                // TODO Just disable the item when it has already been purchased.
                if (!purchased)
                {
                    Instantiate(upgradeItem, PurchaseSelectionGrid.transform);
                }
            }
        }
    }
}