using UnityEngine;

public class SpeedManager : MonoBehaviour {
    
    /// <summary>
    /// The speed manager singleton instance.
    /// </summary>
    [HideInInspector]
    public static SpeedManager instance;

    /// <summary>
    /// The scale of how much the simulation speeds up.
    /// </summary>
    public float SpeedUpScale;

    /// <summary>
    /// Awakening of the speed manager.
    /// </summary>
    void Awake()
    {
        // Only one speed manager can exist.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Speeds up the simulation.
    /// </summary>
    public void SpeedUp()
    {
        Time.timeScale = SpeedUpScale;
    }

    /// <summary>
    /// Set the simulation's speed back to normal.
    /// </summary>
    public void SetToNormalSpeed()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Pauses simulation's speed.
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
    }
}
