using UnityEngine;
using UnityEngine.UI;

namespace UnlockedScene
{
    public class UnlockedCustomerImage : MonoBehaviour
    {
        public Sprite[] CustomerSprites;

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Image>().sprite = CustomerSprites[UnlockCustomerInformation.CustomerNumber];
        }
    }
}