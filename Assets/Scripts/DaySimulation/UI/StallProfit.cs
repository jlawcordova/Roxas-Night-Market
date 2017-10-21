using UnityEngine;
using UnityEngine.UI;
using StallSpace;
using Audio;

namespace DaySimulation.UI
{
    /// <summary>
    /// Represents a stall profit display on the end day panel.
    /// </summary>
    public class StallProfit : MonoBehaviour
    {
        /// <summary>
        /// Icons of the different stalls.
        /// </summary>
        public Sprite[] Icons;

        /// <summary>
        /// The color when the profit is positive.
        /// </summary>
        public Color IncreaseColor;
        /// <summary>
        /// The color when the profit is zero or negative.
        /// </summary>
        public Color DecreaseColor;

        /// <summary>
        /// The sound when the count increases.
        /// </summary>
        public AudioClip CountSound;
        /// <summary>
        /// The audio source of the game object.
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// The current count being displayed.
        /// </summary>
        private int currentProfitCount = 0;
        /// <summary>
        /// The total profit count to be displayed.
        /// </summary>
        private int totalProfitCount = 0;

        /// <summary>
        /// The text object which displays the profit count.
        /// </summary>
        private Text profitText;

        /// <summary>
        /// The index of the profit text.
        /// </summary>
        private const int textIndex = 1;

        /// <summary>
        /// Initialization of the stall profit object.
        /// </summary>
        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            // Set the sound of this game object based on the settings.
            Sound.SetSound(audioSource, 0.25f);

            profitText = gameObject.transform.GetChild(textIndex).GetComponent<Text>();
        }

        /// <summary>
        /// Plays the count sound.
        /// </summary>
        void PlayCountSound()
        {
            audioSource.clip = CountSound;
            audioSource.Play();
        }

        /// <summary>
        /// Updates every frame.
        /// </summary>
        void Update()
        {
            // Decrease or increase the profit count until it reaches the total profit count.
            if (currentProfitCount < totalProfitCount)
            {
                PlayCountSound();
                currentProfitCount++;
                profitText.text = (totalProfitCount > 0 ? "+" : "") + currentProfitCount.ToString();

            }
            else if (currentProfitCount > totalProfitCount)
            {
                PlayCountSound();
                currentProfitCount--;
                profitText.text = (totalProfitCount > 0 ? "+" : "") + currentProfitCount.ToString();
            }
        }

        /// <summary>
        /// Sets the values to be displayed on the stall profit.
        /// </summary>
        /// <param name="spaceType">The type of the stall.</param>
        /// <param name="profitCount">The profit of the stall.</param>
        public void SetValues(StallSpaceType spaceType, int profitCount)
        {
            // Display the proper icon depending on the stall type.
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
                case StallSpaceType.IcecreamStall:
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Icons[2];

                    break;
                case StallSpaceType.FruitShakeStall:
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Icons[3];

                    break;
                case StallSpaceType.Fountain:
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Icons[4];

                    break;
                default:
                    break;
            }

            // Set the total profit count.
            this.totalProfitCount = profitCount;

            // Set the color accordingly.
            profitText = gameObject.transform.GetChild(textIndex).GetComponent<Text>();
            if (this.totalProfitCount > 0)
            {
                profitText.color = IncreaseColor;
            }
            else
            {
                profitText.color = DecreaseColor;
            }
        }
    }
}