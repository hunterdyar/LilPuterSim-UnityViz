using System;
using LilPuter;
using UnityEngine;

namespace Views
{
	public class ALUOneBitSystemsView : ViewBase<ALUOneBit, ALUOneBit>
	{
		[SerializeField] private PinView aView;
		[SerializeField] private PinView bView;
		[SerializeField] private PinView cInView;
		[SerializeField] private PinView cOutView;
		[SerializeField] private PinView resultView;

		private void Start()
		{
			if (StageController.CurrentRoot is ALUOneBit aluView)
			{
				SetComponent(aluView);
			}
		}

		public override void SetComponent(ALUOneBit component)
		{
			base.SetComponent(component);
			aView.SetComponent(component.A);
			bView.SetComponent(component.B);
			cInView.SetComponent(component.CarryIn);
			cOutView.SetComponent(component.CarryOut);
			resultView.SetComponent(component.Result);
		}

		protected override void OnComponentUpdate(ALUOneBit newValue)
		{
			
		}
	}
}