namespace StallSpace.Upgrades
{
    public class IsawGrill : Upgrade
    {
        /// <summary>
        /// The amount of serving time that the grill decreases.
        /// </summary>
        public int ServingTimeDecrease;

        /// <summary>
        /// The grill decreases the serving time.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the music box.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.ServingTime -= ServingTimeDecrease;
        }
    }
}
