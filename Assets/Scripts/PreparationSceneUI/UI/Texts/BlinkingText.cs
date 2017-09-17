using UnityEngine;
using UnityEngine.UI;

namespace PreparationScene.UI.Texts
{
    public class BlinkingText : MonoBehaviour
    {
        public int BlinkDelay;
        public Color TextColor;

        private bool IsVisible = true;
        private int timer;

        // Update is called once per frame
        void Update()
        {
            if (timer > BlinkDelay)
            {
                if (IsVisible)
                {
                    gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
                    IsVisible = false;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = TextColor;
                    IsVisible = true;
                }

                timer = 0;
            }

            timer++;
        }
    }
}