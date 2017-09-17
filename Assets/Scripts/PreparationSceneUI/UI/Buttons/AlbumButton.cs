using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PreparationScene.UI.Buttons
{
    public class AlbumButton : MonoBehaviour, IPointerClickHandler
    {
        public static bool HasNew = false;

        private const int NewTextIndex = 0;

        void Start()
        {
            transform.GetChild(NewTextIndex).gameObject.SetActive(HasNew);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            HasNew = false;
            SceneManager.LoadScene("CustomersScene");
        }
    }
}