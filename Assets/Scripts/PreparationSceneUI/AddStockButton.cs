using UnityEngine;
using UnityEngine.EventSystems;
using StallSpace;

namespace PreparationSceneUI
{
    /// <summary>
    /// The button which adds stock to the selected stall.
    /// </summary>
    public class AddStockButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// The amount of how much the stall's stock increase when clicking this button.
        /// </summary>
        public int StockIncreaseAmount = 10;

        public void OnPointerClick(PointerEventData eventData)
        {
            UIManager.instance.SelectedStallSpace.GetComponent<Stall>().StockCount += StockIncreaseAmount;
        }
    }
}