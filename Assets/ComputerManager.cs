using System;
using System.Text;
using LilPuter;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    private ComputerBase _compy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _compy = new ComputerBase();
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
        _compy.Clock.Cycle();
    }
}
