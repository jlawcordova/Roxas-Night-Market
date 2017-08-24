using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Progress;
using StallSpace;

namespace PreparationSceneUI
{
    public class SellButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            int selectedStallSpaceNumber = UIManager.instance.SelectedStallSpace.GetComponent<Stall>().StallSpaceNumber;
            ProgressManager.StallSpaces[selectedStallSpaceNumber] = new StallSpaceInformation() { StallSpaceNumber = selectedStallSpaceNumber, SpaceType = StallSpaceType.EmptyStall };

            SceneManager.LoadScene(1);
        }
    }
}