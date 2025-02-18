using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
	public class ManualComputerControl : MonoBehaviour
	{
		[SerializeField] private Computer _computer;
		private InputAction _cycleClockCommand;

		private void Awake()
		{
			_cycleClockCommand = InputSystem.actions.FindAction("Operating/CycleClock",true);
			_cycleClockCommand.Enable();
		}

		private void Update()
		{
			if (_cycleClockCommand.WasPressedThisFrame())
			{
				_computer.Tick();
			}else if (_cycleClockCommand.WasReleasedThisFrame())
			{
				_computer.Tock();
			}
		}		
	}
}