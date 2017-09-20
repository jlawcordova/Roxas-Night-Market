using UnityEngine;
using UnityEngine.UI;

namespace PreparationScene.UI
{
    public class MoneyChangeText : MonoBehaviour
    {
        public float YOffsetToDestroy = 0.5f;
        public float YSpeed = 0.005f;
        public Color IncreaseColor;
        public Color DecreaseColor;

        private float totalMove = 0;

        // Update is called once per frame
        void Update()
        {
            if (totalMove < YOffsetToDestroy)
            {
                transform.position += new Vector3(0, YSpeed, 0);
                totalMove += YSpeed;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void UseDecreaseColor()
        {
            gameObject.GetComponent<Text>().color = DecreaseColor;
        }

        public void UseIncreaseColor()
        {
            gameObject.GetComponent<Text>().color = IncreaseColor;
        }
    }
}

