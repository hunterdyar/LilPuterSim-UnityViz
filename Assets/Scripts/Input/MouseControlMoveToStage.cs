using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
	public class MouseControlMoveToStage : MonoBehaviour
	{
		private InputAction _select;

		private void Awake()
		{
			_select = InputSystem.actions.FindAction("Select",true);
			_select.Enable();
		}

		private void Update()
		{
			if (_select.WasPerformedThisFrame())
			{
				var pos = Mouse.current.position.ReadValue();
				var wray = Camera.main.ScreenPointToRay(pos);
				if (Physics.Raycast(wray, out var hit))
				{
					var mtst = hit.collider.GetComponentInParent<MoveToStageTarget>();
					if (mtst != null)
					{
						mtst.Select();
					}
				}
			}
		}
	}
}