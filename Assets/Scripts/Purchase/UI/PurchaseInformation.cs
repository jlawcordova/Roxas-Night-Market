namespace Purchase.UI
{
    /// <summary>
    /// Information on what type of purchase will be made for which stall.
    /// </summary>
    public static class PurchaseInformation
    {
        /// <summary>
        /// The type of purchase to be made.
        /// </summary>
        public static PurchaseType Type;
        /// <summary>
        /// The stall that will be affected by the purchase.
        /// </summary>
        public static int StallToAffect;
    }
}

