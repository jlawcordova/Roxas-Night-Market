using UnityEngine;
using UnityEngine.UI;

namespace Mainscreen
{
    public class TapText : MonoBehaviour
    {
        public int BlinkSpeed;

        public Color OnColor;
        public Color OffColor;

        private bool On = false;

        private int timer = 0;

        private Text text;

        void Start()
        {
            text = gameObject.GetComponent<Text>();

            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (timer < BlinkSpeed)
            {
                timer++;
            }
            else
            {
                Toggle();
                timer = 0;
            }
        }

        void Toggle()
        {
            if (On)
            {
                text.color = OnColor;
                On = !On;
            }
            else
            {
                text.color = OffColor;
                On = !On;
            }
        }
    }
}