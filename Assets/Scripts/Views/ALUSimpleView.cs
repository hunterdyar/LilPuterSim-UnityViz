using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class ALUSimpleView : ViewBase<ALUMultiBit, ALUMultiBit>
	{
		[SerializeField] private Computer _computer;
		[SerializeField] private TMP_Text _AInput;
		[SerializeField] private TMP_Text _BInput;
		[SerializeField] private TMP_Text _OpLabel;
		[SerializeField] private TMP_Text _ResultLabel;

		public void Start()
		{
			//there is only one ALU, so we can set ourselves.
			SetComponent(_computer.GetComputer().CPU.ALU);
		}
		protected override void OnComponentUpdate(ALUMultiBit alu)
		{
			_AInput.text = alu.A.Value.ToString();
			_BInput.text = alu.B.Value.ToString();
			_OpLabel.text = ALUOneBit.OpAsString(alu.Operation.Value);
			_ResultLabel.text = alu.Result.Value.ToString();
		}
	}
}