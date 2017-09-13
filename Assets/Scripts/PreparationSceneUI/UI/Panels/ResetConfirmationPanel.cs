using UnityEngine;

namespace PreparationScene.UI.Panels
{
    public class ResetConfirmationPanel : MonoBehaviour
    {
        [HideInInspector]
        public static ResetConfirmationPanel instance;

        // Use this for initialization
        void Start()
        {
            instance = this;

            gameObject.SetActive(false);
        }
    }
}
