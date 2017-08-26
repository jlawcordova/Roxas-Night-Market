namespace Customer
{
    /// <summary>
    /// Possible customer states.
    /// </summary>
    public enum CustomerState
    {
        // Customer is walking along the street.
        Walking,
        // Customer is walking towards a stall.
        WalkingToStall,
        // Customer is waiting in a stall's line.
        WaitingInLine,
        // Customer is buying from a stall.
        BuyingFromStall,
        // Customer just bought from the stall.
        BoughtFromStall,
        // Customer is walking away from the stall (either after buying, or after losing patience).
        WalkingAwayFromStall
    }
}