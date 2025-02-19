using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Autorunner : MonoBehaviour
{
    [SerializeField] private Computer _computer;
    private float _autorunHz;
    private bool _autorunEnabled;
    private float _timeSinceLastTick;
    
    void Start()
    {
        _timeSinceLastTick = 0.1f;
    }

    public void SetAutorunEnabled(bool isEnabled)
    {
        _autorunEnabled = isEnabled;
    }

    public void SetAutorunSpeed(float hz)
    {
        _autorunHz = hz;
    }

// Update is called once per frame
    void Update()
    {
        if(!_autorunEnabled)
        {
            return;
        }
        
        _timeSinceLastTick -= Time.deltaTime;
        if (_timeSinceLastTick < 0)
        {
            _timeSinceLastTick = 1f/_autorunHz;
            TickOrTick();
        }
    }

    //Trick or Tock!
    private void TickOrTick()
    {
        _computer.TickOrTock();
    }
}
