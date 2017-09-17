using UnityEngine;
using UnityEngine.UI;
using Audio;

namespace Purchase.UI
{
    public class CongratsPanel : MonoBehaviour
    {
        public bool StartHidden;

        /// <summary>
        /// The resize speeds of the shapes on the congrats panel.
        /// </summary>
        public float[] ShapeSpeeds;
        /// <summary>
        /// The final sizes of the shapes on the panel.
        /// </summary>
        public float[] ShapeFinalSizes;

        // Use this for initialization
        void Start()
        {
            // Set the sound of this game object based on the settings.
            Sound.SetSound(gameObject.GetComponent<AudioSource>(), 1);

            if (StartHidden)
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (Music.instance != null)
                {
                    Music.instance.ToggleVolumeNoSave(false);
                }
            }
        }

        /// <summary>
        /// Updates every frame.
        /// </summary>
        void Update()
        {
            // Make the shapes change size.
            for (int i = 0; i < ShapeSpeeds.Length; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height < ShapeFinalSizes[i])
                {
                    gameObject.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta += new Vector2(ShapeSpeeds[i], ShapeSpeeds[i]);
                }
            }
        }

        /// <summary>
        /// Make the congrats panel appear.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemImage"></param>
        public void Appear(string itemName, Sprite itemImage)
        {
            Music.instance.ToggleVolumeNoSave(false);
            gameObject.SetActive(true);

            gameObject.transform.GetChild(3).GetComponent<Text>().text = itemName.Replace("\n", " ");
            gameObject.transform.GetChild(4).GetComponent<Image>().sprite = itemImage;
        }
    }
}