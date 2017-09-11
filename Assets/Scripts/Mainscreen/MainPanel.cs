using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Mainscreen
{
    public class MainPanel : MonoBehaviour, IPointerClickHandler
    {
        // Use this for initialization
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene("PreparationScene");
        }
    }
}