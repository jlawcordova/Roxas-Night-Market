using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Progress;
using StallSpace;

namespace PreparationScene.UI.Buttons
{
    /// <summary>
    /// Handles the sell stall button.
    /// </summary>
    public class SellButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Occurs when the sell stall button is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            int selectedStallSpaceNumber = UIManager.instance.SelectedStallSpace.GetComponent<Stall>().StallSpaceNumber;

            // Set the stall to be empty.
            ProgressManager.StallSpaces[selectedStallSpaceNumber] = new StallSpaceInformation() { StallSpaceNumber = selectedStallSpaceNumber, SpaceType = StallSpaceType.EmptyStall };

            // Reload the scene.
            SceneManager.LoadScene("PreparationScene");
        }
    }
}