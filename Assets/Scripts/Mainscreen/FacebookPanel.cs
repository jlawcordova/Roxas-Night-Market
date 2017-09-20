using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mainscreen
{
    public class FacebookPanel : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Application.OpenURL("https://web.facebook.com/CordlessGames");
        }
    }
}

