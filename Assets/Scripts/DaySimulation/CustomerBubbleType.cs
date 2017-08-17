using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaySimulation
{
    /// <summary>
    /// The different types of customer bubbles.
    /// </summary>
    public enum CustomerBubbleType
    {
        // Happy customer bubble. Apeears after the customer buys from a stall
        Happy,
        // Time customer bubble. Appears when the customer is impatient.
        Time,
        // KwekKwek customer bubble. Appears when the customer is buying kwekkwek.
        Kwekkwek
    }
}
