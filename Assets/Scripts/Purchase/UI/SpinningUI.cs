using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purchase.UI
{
    /// <summary>
    /// Represents a spinning UI object.
    /// </summary>
    public class SpinningUI : MonoBehaviour
    {
        /// <summary>
        /// The speed of the spin.
        /// </summary>
        public float SpinSpeed;

        /// <summary>
        /// Stores the rect transform of the game object.
        /// </summary>
        private RectTransform rect;

        // Use this for initialization
        void Start()
        {
            rect = gameObject.GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void Update()
        {
            rect.Rotate(new Vector3(0, 0, SpinSpeed));
        }
    }
}