using UnityEngine;

namespace PreparationScene.UI.Panels
{
    public class SellConfirmationPanel : MonoBehaviour
    {
        [HideInInspector]
        public static SellConfirmationPanel instance;

        // Use this for initialization
        void Start()
        {
            instance = this;
            
            gameObject.SetActive(false);
        }
    }
}