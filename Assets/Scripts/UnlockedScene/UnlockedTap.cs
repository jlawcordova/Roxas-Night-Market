using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using PreparationScene.UI.Panels;

public class UnlockedTap : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GuidePanel.IsShown = true;
        SceneManager.LoadScene("PreparationScene");
    }
}
