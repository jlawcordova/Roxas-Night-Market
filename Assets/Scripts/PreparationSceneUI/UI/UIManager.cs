using UnityEngine;
using StallSpace;

namespace PreparationScene.UI
{
    /// <summary>
    /// Manages the UI on the screen.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [HideInInspector]
        public static UIManager instance;
        
        /// <summary>
        /// The selection panel that will appear when clicking the empty stall.
        /// </summary>
        public GameObject DisplayedSelectionPanel;

        /// <summary>
        /// The current selected object on the screen which this panel is representing.
        /// </summary>
        [HideInInspector]
        public GameObject SelectedStallSpace = null;
        public GameObject LastSelectedStallSpace;
        [HideInInspector]
        public StallSpaceType SelectedStallSpaceType;

        // Use this for initialization
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
