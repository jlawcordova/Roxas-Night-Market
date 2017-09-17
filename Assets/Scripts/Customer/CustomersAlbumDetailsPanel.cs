using UnityEngine;
using UnityEngine.UI;

namespace Customer.UI
{
    public class CustomersAlbumDetailsPanel : MonoBehaviour
    {
        public Sprite LockedCustomer;

        private const int CustomerNameIndex = 0;
        private const int CustomerImageIndex = 1;
        private const int CustomerDetailsIndex = 2;

        // Use this for initialization
        void Start()
        {
            CustomerAlbumItem.CustomerAlbumItemClicked += CustomerAlbumItem_CustomerAlbumItemClicked;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private void CustomerAlbumItem_CustomerAlbumItemClicked(object sender, System.EventArgs e)
        {
            if (this != null)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                if (CustomerAlbumItem.SelectedCustomerAlbumItem.IsLocked)
                {
                    gameObject.transform.GetChild(CustomerNameIndex).GetComponent<Text>().text = "Locked";
                    gameObject.transform.GetChild(CustomerImageIndex).GetComponent<Image>().sprite = LockedCustomer;
                    gameObject.transform.GetChild(CustomerDetailsIndex).GetComponent<Text>().text = CustomerAlbumItem.SelectedCustomerAlbumItem.CustomerLockedDetails;
                }
                else
                {
                    gameObject.transform.GetChild(CustomerNameIndex).GetComponent<Text>().text = CustomerAlbumItem.SelectedCustomerAlbumItem.CustomerName;
                    gameObject.transform.GetChild(CustomerImageIndex).GetComponent<Image>().sprite = CustomerAlbumItem.SelectedCustomerAlbumItem.CustomerSprite;
                    gameObject.transform.GetChild(CustomerDetailsIndex).GetComponent<Text>().text = CustomerAlbumItem.SelectedCustomerAlbumItem.CustomerDetails;
                }
            }
        }
    }
}