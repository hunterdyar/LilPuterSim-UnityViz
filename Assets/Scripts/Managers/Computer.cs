using System.Text;
using LilPuter;
using UnityEngine;

[CreateAssetMenu(fileName = "Computer", menuName = "LilPuter/Computer", order = 0)]
public class Computer : ScriptableObject
{
    private ComputerBase _compy;
    [TextArea(10,30)]
    public string TestProgram;

    private bool _lastTickWasTick;
    public ComputerBase GetComputer()
    {
        //Lazy init because ScriptableObject Loading.
        if (_compy == null)
        {
            _compy = new ComputerBase();
        }

        _lastTickWasTick = false;
        return _compy;
    }

    public void LoadTestProgram()
    {
        _compy.CPU.LoadProgram(TestProgram);
        _compy.CPU.Output.OnOutput += (value) =>
        {
            Debug.Log("Compy: "+value);
        };
    }
    
    [ContextMenu("Tick")]
    public void Tick()
    {
        GetComputer().Clock.Tick();
    }

    [ContextMenu("Tock")]
    public void Tock()
    {
        GetComputer().Clock.Tock();
    }

    [ContextMenu("Execute One Instruction")]
    public void ExecuteOnce()
    {
        GetComputer().ExecuteOneInstruction();
    }

    /// <summary>
    /// Calls Tick() or Tick() alternatingly.
    /// </summary>
    public void TickOrTock()
    {
        if (_lastTickWasTick)
        {
            Tock();
            _lastTickWasTick = false;
        }
        else
        {
            Tick();
            _lastTickWasTick = true;
        }
    }
}
