using System;
using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class MicroinstructionBar : ViewBase<CPUInstructionManager, CPUInstructionManager>
	{
		[SerializeField] private Computer _computer;
		[SerializeField] private SlidePositionAnimator _currentInstructionBar;
		[SerializeField] private TMP_Text _instructionLabel;
		[SerializeField] private TMP_Text[] _codes;
		
		private void Start()
		{
			SetComponent(_computer.GetComputer().CPU.MicrocodeDecoder);
		}

		protected override void OnComponentUpdate(CPUInstructionManager mcc)
		{
			_currentInstructionBar.SetPosition(mcc.Counter.Out.Value);
			//GetCode
			var address = _computer.GetComputer().CPU.InstructionMemory.Instruction.Value;
			_instructionLabel.text = mcc.GetOpcodeName(address);
			for (int i = 0; i < _codes.Length; i++)
			{
				var c = _computer.GetComputer().CPU.Bus.GetConnectionsForCode(mcc.Microcode.Registers[mcc.MakeMicrocodeAddress(address,i)]);

				_codes[i].text = "";
				foreach (var bc in c)
				{
					//Temp skip for the not-yet-fully-implemented end instruction early bit.
					if (bc.Name == "END")
					{
						continue;
					}
					_codes[i].text += bc.Name+" ";
				}
			}
		}
	}
}