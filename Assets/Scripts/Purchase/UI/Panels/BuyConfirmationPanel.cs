using StallSpace.Upgrades;
using UnityEngine;
using UnityEngine.UI;

namespace Purchase.UI
{
    public class BuyConfirmationPanel : MonoBehaviour
    {
        public static BuyConfirmationPanel instance;

        public UpgradeData Upgrade;
        public UpgradeData RemovableUpgrade;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        // Use this for initialization
        void Start()
        {
            gameObject.SetActive(false);
        }

        void OnEnable()
        {
            if (RemovableUpgrade != null)
            {
                if (RemovableUpgrade.Name != null)
                {
                    transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "This upgrade will replace your " + RemovableUpgrade.Name.Replace("\n", " ")
                    + ". Do you want to continue?";
                }
            }
        }
    }
}