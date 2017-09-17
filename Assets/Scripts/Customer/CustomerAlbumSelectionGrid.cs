using UnityEngine;
using Progress;

namespace Customer.UI
{
    public class CustomerAlbumSelectionGrid : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            foreach (int customersUnlocked in ProgressManager.CustomersUnlocked)
            {
                transform.GetChild(customersUnlocked).GetComponent<CustomerAlbumItem>().Unlock();
            }
        }
    }
}