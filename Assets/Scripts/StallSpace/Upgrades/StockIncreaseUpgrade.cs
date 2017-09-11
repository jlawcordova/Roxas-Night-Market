namespace StallSpace.Upgrades
{
    public class StockIncreaseUpgrade : Upgrade
    {
        /// <summary>
        /// The amount of maximum stock that the kwekkwek bowl increases.
        /// </summary>
        public int MaximumStockIncrease;

        /// <summary>
        /// The kwekkwek bowl increases the maximum stock count.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the music box.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.MaxStockCount += MaximumStockIncrease;
        }
    }
}
