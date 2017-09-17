using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using PreparationScene.UI.Buttons;

public class UnlockedCustomerTap : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AlbumButton.HasNew = true;
        SceneManager.LoadScene("PreparationScene");
    }
}

