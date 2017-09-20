using StallSpace;
using UnityEngine;
using UnityEngine.UI;

namespace PreparationScene.UI.Panels
{
    public class SellConfirmationPanel : MonoBehaviour
    {
        [HideInInspector]
        public static SellConfirmationPanel instance;

        // Use this for initialization
        void Start()
        {
            instance = this;
            
            gameObject.SetActive(false);
        }

        void OnEnable()
        {
            if (UIManager.instance != null)
            {
                int stallCost = UIManager.instance.LastSelectedStallSpace.GetComponent<Stall>().StallSellCost;
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Are you sure you want to sell this stall for " + stallCost + " coins?";
            }
        }
    }
}