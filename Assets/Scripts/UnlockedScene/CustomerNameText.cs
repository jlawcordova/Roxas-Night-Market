using UnityEngine;
using UnityEngine.UI;

namespace UnlockedScene
{
    public class CustomerNameText : MonoBehaviour
    {
        public string[] CustomerNames;

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Text>().text = CustomerNames[UnlockCustomerInformation.CustomerNumber];
        }
    }
}