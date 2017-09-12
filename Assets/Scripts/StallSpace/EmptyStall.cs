using UnityEngine;

namespace StallSpace
{
    /// <summary>
    /// Represents an empty stall space.
    /// </summary>
    public class EmptyStall : StallSpace, IHighlightable
    {
        [SerializeField]
        private Color highlightColor;
        public Color HighlightColor { get; set; }

        [SerializeField]
        private Color removeHighlightColor;
        public Color RemoveHighlightColor { get; set; }

        public void Highlight()
        {
            gameObject.GetComponent<Renderer>().material.color = highlightColor;
        }

        public void RemoveHighlight()
        {
            gameObject.GetComponent<Renderer>().material.color = removeHighlightColor;
        }
    }
}