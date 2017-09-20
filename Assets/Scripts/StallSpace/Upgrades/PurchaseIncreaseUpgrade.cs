namespace StallSpace.Upgrades
{
    public class PurchaseIncreaseUpgrade : Upgrade
    {
        /// <summary>
        /// The purchase increase of the stall's product.
        /// </summary>
        public int PurchaseIncrease;

        /// <summary>
        /// The upgrade increases the product purchase.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the upgrade.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.StallProductPurchaseCost += PurchaseIncrease;
        }
    }
}
