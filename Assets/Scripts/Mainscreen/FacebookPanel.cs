using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mainscreen
{
    public class FacebookPanel : MonoBehaviour, IPointerClickHandler
    {
        public string ClickURL;

        public void OnPointerClick(PointerEventData eventData)
        {
            Application.OpenURL(ClickURL);
        }
    }
}

