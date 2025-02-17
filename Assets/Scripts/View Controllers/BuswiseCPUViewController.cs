using System;
using System.Text;
using LilPuter;
using UnityEngine;
using Views;

public class BuswiseCPUViewController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]private Computer _comp;
    [Header("Configuration")]
    [SerializeField] private RegisterView _aRegisterView;
    [SerializeField] private RegisterView _bRegisterView;
    [SerializeField] private ClockTickView _clockTickView;
    [SerializeField] private CounterView _programCounterView;
    [SerializeField] private CounterView _microcodeCounterView;
    private void Awake()
    {
        var compy = _comp.GetComputer();
        //Initialize the view.
        _aRegisterView.SetComponent(compy.CPU.A);
        _bRegisterView.SetComponent(compy.CPU.B);
        _clockTickView.SetComponent(compy.Clock.ClockIsHighPin);
        _programCounterView.SetComponent(compy.CPU.PC);
        _microcodeCounterView.SetComponent(compy.CPU.MicrocodeDecoder.Counter);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _comp.LoadTestProgram();
    }

    //Todo: Computer input should not be in this view controller.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _comp.Tick();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _comp.Tock();
        }
    }
}
