using UnityEngine;
using UnityEngine.UI;
using StallSpace;

namespace DaySimulation.UI
{
    public class StallProfit : MonoBehaviour
    {
        public Sprite[] Icons;

        public Color IncreaseColor;
        public Color DecreaseColor;

        public AudioClip CountSound;
        private AudioSource audioSource;

        private int currentProfitCount = 0;
        private int profitCount = 0;
        private Text profitText;

        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            profitText = gameObject.transform.GetChild(1).GetComponent<Text>();
        }

        void PlayCountSound()
        {
            audioSource.clip = CountSound;
            audioSource.Play();
        }

        void Update()
        {
            if (currentProfitCount < profitCount)
            {
                PlayCountSound();
                currentProfitCount++;
                profitText.text = (profitCount > 0 ? "+" : "") + currentProfitCount.ToString();

            }
            else if (currentProfitCount > profitCount)
            {
                PlayCountSound();
                currentProfitCount--;
                profitText.text = (profitCount > 0 ? "+" : "") + currentProfitCount.ToString();
            }
        }

        public void SetValues(StallSpaceType spaceType, int profitCount)
        {
            switch (spaceType)
            {
                case StallSpaceType.EmptyStall:
                    break;
                case StallSpaceType.KwekKwekStall:
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Icons[0];

                    break;
                case StallSpaceType.IsawStall:
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Icons[1];

                    break;
                default:
                    break;
            }

            this.profitCount = profitCount;

            if (this.profitCount > 0)
            {
                gameObject.transform.GetChild(1).GetComponent<Text>().color = IncreaseColor;
            }
            else
            {
                gameObject.transform.GetChild(1).GetComponent<Text>().color = DecreaseColor;
            }
        }
    }
}