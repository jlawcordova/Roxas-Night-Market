using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Progress;

namespace PurchaseUI
{
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            // TODO Stall space type must vary depending on selected purchase.
            ProgressManager.StallSpaces[PurchaseInformation.StallToAffect].SpaceType = StallSpace.StallSpaceType.Stall;

            SceneManager.LoadScene(1);
        }
    }
}
