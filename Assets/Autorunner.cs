using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Autorunner : MonoBehaviour
{
    [SerializeField] private Computer _computer;
    private float autorunHz;
    private bool autorunEnabled;
    private float timeSinceLastTick;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeSinceLastTick = 0.1f;
    }

    public void SetAutorunEnabled(bool isEnabled)
    {
        autorunEnabled = isEnabled;
    }

    public void SetAutorunSpeed(float hz)
    {
        autorunHz = hz;
    }

// Update is called once per frame
    void Update()
    {
        if(!autorunEnabled)
        {
            return;
        }
        
        timeSinceLastTick -= Time.deltaTime;
        if (timeSinceLastTick < 0)
        {
            timeSinceLastTick = 1f/autorunHz;
            TickOrTick();
        }
    }

    //Trick or Tock!
    private void TickOrTick()
    {
        _computer.TickOrTock();
    }
}
