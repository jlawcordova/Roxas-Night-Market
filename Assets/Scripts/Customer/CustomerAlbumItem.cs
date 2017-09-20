using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Customer.UI
{
    /// <summary>
    /// Represents an item on the customer album.
    /// </summary>
    public class CustomerAlbumItem : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// The single selected item on the customer album.
        /// </summary>
        public static CustomerAlbumItem SelectedCustomerAlbumItem;
        
        public string CustomerName;
        public Sprite CustomerSprite;
        [TextArea]
        public string CustomerDetails;
        [TextArea]
        public string CustomerLockedDetails;

        [HideInInspector]
        public bool IsLocked = true;

        private const int CustomerImageIndex = 0;

        public Sprite SelectedImage;
        public Sprite NotSelectedImage;

        public static event EventHandler CustomerAlbumItemClicked;

        /// <summary>
        /// Unlocks the item.
        /// </summary>
        public void Unlock()
        {
            gameObject.transform.GetChild(CustomerImageIndex).GetComponent<Image>().sprite = CustomerSprite;

            IsLocked = false;
        }

        /// <summary>
        /// Occurs when the gameobject is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (SelectedCustomerAlbumItem != null)
            {
                SelectedCustomerAlbumItem.GetComponent<Image>().sprite = NotSelectedImage;
            }
            gameObject.GetComponent<Image>().sprite = SelectedImage;

            SelectedCustomerAlbumItem = this;
            OnCustomerAlbumItemClicked();
        }

        void OnCustomerAlbumItemClicked()
        {
            if (CustomerAlbumItemClicked != null)
            {
                CustomerAlbumItemClicked(this, EventArgs.Empty);
            }
        }
    }
}