using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using StallSpace;
using PurchaseUI;

namespace PreparationSceneUI
{
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PurchaseInformation.StallToAffect = UIManager.instance.SelectedStallSpace.GetComponent<Progress.IStallSpaceInformation>().StallSpaceNumber;
            SceneManager.LoadScene(3);
        }
    }
}