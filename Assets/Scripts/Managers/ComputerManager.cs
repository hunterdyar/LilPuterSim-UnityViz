using System;
using System.Text;
using LilPuter;
using UnityEngine;
using Views;

public class ComputerManager : MonoBehaviour
{
    private ComputerBase _compy;

    [SerializeField] private BusView _busView;
    [SerializeField] private RegisterView _aRegisterView;
    [SerializeField] private RegisterView _bRegisterView;
    [SerializeField] private ClockTickView _clockTickView;
    [SerializeField] private CounterView _programCounterView;
    [SerializeField] private CounterView _microcodeCounterView;
    private void Awake()
    {
        _compy = new ComputerBase();
        //Initialize the view.
        _busView.SetComponent(_compy.CPU.Bus);
        _aRegisterView.SetComponent(_compy.CPU.A);
        _bRegisterView.SetComponent(_compy.CPU.B);
        _clockTickView.SetComponent(_compy.Clock.ClockIsHighPin);
        _programCounterView.SetComponent(_compy.CPU.PC);
        _microcodeCounterView.SetComponent(_compy.CPU.MicrocodeDecoder.Counter);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //
        var sb = new StringBuilder();
        sb.AppendLine("LDAI 22");
        sb.AppendLine("LDBI 20");
        sb.AppendLine("ADD");
        sb.AppendLine("OUT");
        sb.AppendLine("HLT");
        _compy.CPU.LoadProgram(sb.ToString());
        _compy.CPU.Output.OnOutput += (value) =>
        {
            Debug.Log("Compy: "+value);
        };
    }

    private void Update()
    {
        //_compy.Clock.Cycle();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _compy.Clock.Tick();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _compy.Clock.Tock();
        }
    }
}
