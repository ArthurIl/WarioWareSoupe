using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;
using UnityEngine.SceneManagement;

public class TimedBehaviour : MonoBehaviour
{
   [HideInInspector] public float bpm = 60;
    [HideInInspector] public Manager.Difficulty currentDifficulty = 0;

    public double timer;

    // Tick increments on every TimedUpdate(), at 8 you must call the result
    public int Tick
    {
        get;
        private set;
    }

    public virtual void Start()
    {
        if (SceneManager.GetActiveScene().name == "TestingScene")
        {
            bpm =(float) Manager.Instance.bpm;
            currentDifficulty = Manager.Instance.currentDifficulty;
        }
    }


    public virtual void FixedUpdate()
    {
        timer = AudioSettings.dspTime - Manager.Instance.currentTime;
        if (timer >= 60 / bpm && Manager.Instance.hasLoaded)
        {
            Tick++;
            Manager.Instance.currentTime = AudioSettings.dspTime;
            TimedUpdate();
        }
    }
  

    /// <summary>
    /// TimedUdpate is called at each tick. Use this if you want your script to update with rythme.
    /// </summary>
    public virtual void TimedUpdate()
    {
        
    }

}
