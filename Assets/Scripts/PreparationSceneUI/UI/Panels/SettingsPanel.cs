using UnityEngine;

namespace PreparationScene.UI.Panels
{
    public class SettingsPanel : MonoBehaviour
    {
        [HideInInspector]
        public static SettingsPanel instance;

        // Use this for initialization
        void Start()
        {
            instance = this;

            gameObject.SetActive(false);
        }
    }
}