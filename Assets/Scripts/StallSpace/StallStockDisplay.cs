using UnityEngine;

namespace StallSpace
{
    public class StallStockDisplay : MonoBehaviour
    {
        public void SetStockCount(int stockCount)
        {
            transform.GetChild(2).GetComponent<TextMesh>().text = stockCount.ToString();
        }
    }
}