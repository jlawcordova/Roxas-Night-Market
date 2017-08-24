using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PurchaseUI
{
    public class PurchaseItem : MonoBehaviour, IPointerClickHandler
    {
        public static PurchaseItem SelectedPurchaseItem;

        public void OnPointerClick(PointerEventData eventData)
        {
            PurchaseItem.SelectedPurchaseItem = this;
        }
    }
}