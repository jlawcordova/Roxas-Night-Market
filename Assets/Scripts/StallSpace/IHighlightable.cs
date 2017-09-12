using UnityEngine;

namespace StallSpace
{
    public interface IHighlightable
    {
        Color HighlightColor { get; set; }
        Color RemoveHighlightColor { get; set; }

        void Highlight();
        void RemoveHighlight();
    }
}