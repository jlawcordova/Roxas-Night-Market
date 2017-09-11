using UnityEngine;

namespace PreparationScene.UI.Texts
{
    /// <summary>
    /// Handles 3d text.
    /// </summary>
    public class ThreeDimensionText : MonoBehaviour
    {
        // Awakening of the 3d text.
        void Awake()
        {
            // Set the layer order to be in the StallBubbleLayer.
            gameObject.GetComponent<MeshRenderer>().sortingLayerName = "StallBubble";
            gameObject.GetComponent<MeshRenderer>().sortingOrder = 1;
        }
    }
}

