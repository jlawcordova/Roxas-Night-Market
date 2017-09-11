using UnityEngine;

namespace StallSpace.Upgrades
{
    /// <summary>
    /// All upgrades must follow this interface.
    /// </summary>
    public abstract class Upgrade : MonoBehaviour
    {
        /// <summary>
        /// The offset of the upgrade display with respect to the stall.
        /// </summary>
        public Vector3 Offset;

        /// <summary>
        /// Used to make the upgrade take effect.
        /// </summary>
        /// <param name="stallToAffect">The stall that will be affected by the upgrade.</param>
        public abstract void TakeEffect(Stall stallToAffect);

        /// <summary>
        /// Initialization of the upgrade object.
        /// </summary>
        void Start()
        {
            transform.position = transform.parent.position + Offset;
        }
    }
}