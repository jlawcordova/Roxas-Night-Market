using UnityEngine;

namespace Progress
{
    /// <summary>
    /// Gets progress from a file during game start.
    /// </summary>
    public class ProgressGetter : MonoBehaviour
    {
        // Performed when the progress getter is enabled.
        void Awake()
        {
            ProgressManager.GetProgressFromFile();
        }
    }
}