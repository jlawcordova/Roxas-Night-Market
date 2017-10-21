using Progress;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Mainscreen
{
    /// <summary>
    /// Handles the main panel in the mainscreen.
    /// </summary>
    public class MainPanel : MonoBehaviour, IPointerClickHandler
    {
        public GameObject FadingObject;

        // Use this for initialization
        void Start()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Occurs when the main panel is clicked.
        /// </summary>
        /// <param name="eventData">Data on the pointer click event.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            FadingObject.SetActive(true);

            //if (ProgressManager.TutorialMode)
            //{
            //    SceneManager.LoadScene("StartStoryScene");
            //}
            //else
            //{
            //    // Special case where the user has not finished the ending scene.
            //    if (ProgressManager.Day == 100)
            //    {
            //        if (PlayerPrefs.GetInt("EndingCompleted") == 0)
            //        {
            //            SceneManager.LoadScene("GoodEndingScene");
            //        }
            //        else
            //        {
            //            SceneManager.LoadScene("PreparationScene");
            //        }
            //    }
            //    else
            //    {
            //        SceneManager.LoadScene("PreparationScene");
            //    }
            //}
        }
    }
}