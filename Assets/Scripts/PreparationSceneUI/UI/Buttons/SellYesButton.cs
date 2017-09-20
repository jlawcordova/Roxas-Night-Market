using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using StallSpace;
using Progress;

namespace PreparationScene.UI.Buttons
{
    public class SellYesButton : MonoBehaviour, IPointerClickHandler
    {

        /// <summary>
        /// Occurs when the sell stall button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            int selectedStallSpaceNumber = UIManager.instance.LastSelectedStallSpace.GetComponent<Stall>().StallSpaceNumber;

            ProgressManager.Money += UIManager.instance.LastSelectedStallSpace.GetComponent<Stall>().StallSellCost;

            // Set the stall to be empty.
            ProgressManager.StallSpaces[selectedStallSpaceNumber] = new StallSpaceInformation() { StallSpaceNumber = selectedStallSpaceNumber, SpaceType = StallSpaceType.EmptyStall };

            // Reload the scene.
            SceneManager.LoadScene("PreparationScene");
        }
    }

}