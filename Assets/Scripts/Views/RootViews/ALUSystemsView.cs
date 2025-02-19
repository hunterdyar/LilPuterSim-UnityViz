using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class ALUSystemsView : ViewBase<ALUMultiBit, ALUMultiBit>
	{
		[Header("References")]
		[SerializeField] private Computer _computer;

		[Header("TMP")]
		[SerializeField] private TMP_Text _AInput;
		[SerializeField] private TMP_Text _BInput;
		[SerializeField] private TMP_Text _OpLabel;
		[SerializeField] private TMP_Text _ResultLabel;

		[Header("Pin Sets")]
		[SerializeField] private ExplodedPinView _a;
		[SerializeField] private ExplodedPinView _b;
		[SerializeField] private ExplodedPinView _out;
		
		[Header("Adders")]
		[SerializeField] private OneBitAluView[] _adders;
		public void Start()
		{
			//there is only one ALU, so we can set ourselves.
			SetComponent(_computer.GetComputer().CPU.ALU);
		}

		public override void SetComponent(ALUMultiBit alu)
		{
			base.SetComponent(alu);
			_a.SetComponent(alu.A);
			_b.SetComponent(alu.B);
			_out.SetComponent(alu.Result);
			
			Debug.Assert(alu.ALUOneBits.Length == _adders.Length);
			for (int i = 0; i < alu.ALUOneBits.Length; i++)
			{
				_adders[i].SetComponent(alu.ALUOneBits[i]);
			}
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