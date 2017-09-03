using System;
using UnityEngine;

namespace StallSpace.Upgrades
{
    public class MusicBoxUpgrade : Upgrade
    {
        /// <summary>
        /// The amount of attraction percentage that the music box increases.
        /// </summary>
        public int AttractionPercentageIncrease;

        /// <summary>
        /// The music box adds 20% attraction percentage.
        /// </summary>
        /// <param name="stallToAffect">The stall to be affected by the music box.</param>
        public override void TakeEffect(Stall stallToAffect)
        {
            stallToAffect.AttractionPercentage += AttractionPercentageIncrease;
        }
    }
}

