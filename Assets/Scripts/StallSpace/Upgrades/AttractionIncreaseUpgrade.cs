namespace StallSpace.Upgrades
{
    public class AttractionIncreaseUpgrade : Upgrade
    {
        /// <summary>
        /// The amount of attraction percentage that the upgrade increases.
        /// </summary>
        public int AttractionPercentageIncrease;

        /// <summary>
        /// The upgrade adds attraction percentage.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the upgrade.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.AttractionPercentage += AttractionPercentageIncrease;
        }
    }
}