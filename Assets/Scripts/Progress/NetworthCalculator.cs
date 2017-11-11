using Purchase.UI;
using StallSpace;
using StallSpace.Upgrades;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Progress
{
    /// <summary>
    /// Calculates the total networth of the player.
    /// </summary>
    public class NetworthCalculator : MonoBehaviour
    {
        public int[] StallValues;

        public GameObject[] KwekKwekStallUpgradeValues;
        public GameObject[] IsawStallUpgradeValues;
        public GameObject[] IcecreamStallUpgradeValues;
        public GameObject[] FruitShakeStallUpgradeValues;
        public GameObject[] FountainUpgradeValues;

        public int CalculateNetworth()
        {
            int Networth = 0;

            // Add all the values of the stalls (including upgrades).
            foreach (StallSpaceInformation stallSpace in ProgressManager.StallSpaces)
            {
                int value = 0;

                if (stallSpace != null)
                {
                    switch (stallSpace.SpaceType)
                    {
                        case StallSpaceType.EmptyStall:
                            value += StallValues[0];
                            break;
                        case StallSpaceType.KwekKwekStall:
                            value = StallValues[1];
                            value += GetUpgradesValue(stallSpace, KwekKwekStallUpgradeValues);
                            break;
                        case StallSpaceType.IsawStall:
                            value = StallValues[2];
                            value += GetUpgradesValue(stallSpace, IsawStallUpgradeValues);
                            break;
                        case StallSpaceType.IcecreamStall:
                            value = StallValues[3];
                            value += GetUpgradesValue(stallSpace, IcecreamStallUpgradeValues);
                            break;
                        case StallSpaceType.FruitShakeStall:
                            value = StallValues[4];
                            value += GetUpgradesValue(stallSpace, FruitShakeStallUpgradeValues);
                            break;
                        case StallSpaceType.Fountain:
                            value = StallValues[5];
                            value += GetUpgradesValue(stallSpace, FountainUpgradeValues);
                            break;
                        default:
                            break;
                    }
                }

                Networth += value;
            }

            Networth += ProgressManager.Money;

            return Networth;
        }

        /// <summary>
        /// Gets the value of the upgrades.
        /// </summary>
        /// <param name="stallSpace">The stall space whose updrages values are to be totaled.</param>
        /// <param name="upgradeValues">The values of each upgrade.</param>
        /// <returns></returns>
        int GetUpgradesValue(StallSpaceInformation stallSpace, GameObject[] upgradeValues)
        {
            int upgradesValue = 0;

            if (stallSpace.StallUpgrades != null)
            {
                foreach (UpgradeData upgrade in stallSpace.StallUpgrades)
                {
                    upgradesValue += upgradeValues[upgrade.UpgradeNumber].GetComponent<UpgradePurchaseItemPanel>().ItemCost;
                }
            }

            return upgradesValue;
        }
    }
}