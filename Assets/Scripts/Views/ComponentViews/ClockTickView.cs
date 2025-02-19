using LilPuter;
using UnityEngine;

public class ClockTickView : ViewBase<Pin,int>
{
    [SerializeField] private Transform _spinner;
    public Quaternion _tockRot;
    public Quaternion _tickRot;
    public PinView _clockLED;
    
    protected override void OnComponentUpdate(int newValue)
    {
        _spinner.rotation = newValue == 1 ? _tickRot : _tockRot;
    }

    public override void SetComponent(Pin component)
    {
        base.SetComponent(component);
        _clockLED.SetComponent(component);
    }
}
