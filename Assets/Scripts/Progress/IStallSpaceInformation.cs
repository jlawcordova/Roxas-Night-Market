using StallSpace;

namespace Progress
{
    /// <summary>
    /// Interface for denoting stall space information.
    /// </summary>
    public interface IStallSpaceInformation
    {
        StallSpaceType SpaceType { get; set; }
        int StallSpaceNumber { get; set; }
        int StockCount { get; set; }
    }
}