namespace StallSpace.Upgrades
{
    public class AppleCiderVinegar : Upgrade
    {
        /// <summary>
        /// The purchase increase of the stall's product.
        /// </summary>
        public int PurchaseIncrease;

        /// <summary>
        /// The kwekkwek bowl increases the maximum stock count.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the music box.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.StallProductPurchaseCost += PurchaseIncrease;
        }
    }
}
