namespace StallSpace.Upgrades
{
    public class ServeTimeDecreaseUpgrade : Upgrade
    {
        /// <summary>
        /// The amount of serving time that the upgrade decreases.
        /// </summary>
        public int ServingTimeDecrease;

        /// <summary>
        /// The upgrade decreases the serving time.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the upgrade.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.ServingTime -= ServingTimeDecrease;
        }
    }
}
