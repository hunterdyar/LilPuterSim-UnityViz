using DefaultNamespace;
using LilPuter;
using UnityEngine;

namespace Views
{
	public class OneBitAluView : ViewBase<ALUOneBit,ALUOneBit>, ISelectableViaCollider
	{
		[SerializeField] private Stage _stage;
		[Header("Configuration")]
		[SerializeField] private PinView aView;
		[SerializeField] private PinView bView;
		[SerializeField] private PinView cInView;
		[SerializeField] private PinView cOutView;
		[SerializeField] private PinView resultView;
		
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

		public void Select()
		{
			StageController.Instance.LoadStage(_stage, _component);
		}
	}
}