using System.Text;
using LilPuter;
using UnityEngine;

[CreateAssetMenu(fileName = "Computer", menuName = "LilPuter/Computer", order = 0)]
public class Computer : ScriptableObject
{
    private ComputerBase _compy;
    [TextArea(10,30)]
    public string TestProgram;
    public ComputerBase GetComputer()
    {
        //Lazy init because ScriptableObject Loading.
        if (_compy == null)
        {
            _compy = new ComputerBase();
        }
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

    public void Tick()
    {
        GetComputer().Clock.Tick();
    }

    public void Tock()
    {
        GetComputer().Clock.Tock();
    }
}
