namespace StallSpace.Upgrades
{
    public class PatienceIncreaseUpgrade : Upgrade
    {
        /// <summary>
        /// The amount of patience that the upgrade increases.
        /// </summary>
        public int PatiencePercentageIncrease;

        /// <summary>
        /// The upgrade increases patience.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the upgrade.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.PatienceIncrease += PatiencePercentageIncrease;
        }
    }
}
