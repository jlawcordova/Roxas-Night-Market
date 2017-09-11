using UnityEngine;

namespace Progress
{
    /// <summary>
    /// Tracks the amount of money the player has used on restocking and the profit afterwards.
    /// </summary>
    public class ProfitTracker : MonoBehaviour
    {
        public static ProfitTracker instance;

        public int[] StallProfit;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            StallProfit = new int[ProgressManager.StallSpaces.Length];

            DontDestroyOnLoad(gameObject);
        }

        public void Reset()
        {
            for (int i = 0; i < StallProfit.Length; i++)
            {
                StallProfit[i] = 0;
            }
        }
    }
}

