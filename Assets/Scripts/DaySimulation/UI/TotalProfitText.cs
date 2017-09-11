using UnityEngine;
using UnityEngine.UI;

namespace DaySimulation.UI
{
    public class TotalProfitText : MonoBehaviour
    {
        public Color IncreaseColor;
        public Color DecreaseColor;

        public int TotalProfit
        {
            get
            {
                return totalProfit;
            }
            set
            {
                totalProfit = value;

                gameObject.GetComponent<Text>().text = (totalProfit > 0 ? "+" : "") + totalProfit.ToString();
                if (totalProfit > 0)
                {
                    gameObject.GetComponent<Text>().color = IncreaseColor;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = DecreaseColor;
                }
            }
        }
        private int totalProfit;
        
        // Use this for initialization
        void Start()
        {
            totalProfit = 0;
        }
    }
}