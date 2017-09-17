using Progress;
using UnityEngine;
using UnityEngine.UI;

namespace PreparationScene.UI.Texts
{
    public class DayText : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Text>().text = "Day " + ProgressManager.Day.ToString();
        }
    }
}