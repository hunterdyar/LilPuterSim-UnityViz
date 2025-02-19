using Configuration;
using LilPuter;
using UnityEngine;

namespace Views
{
	public class ExplodedPinView : ViewBase<Pin,int>
	{
		[SerializeField] private MeshRenderer[] _pins;
		
		[ContextMenu("Get Children Meshes")]
		private void GetChildMeshes()
		{
			_pins = GetComponentsInChildren<MeshRenderer>();
		}

		public override void SetComponent(Pin component)
		{
			base.SetComponent(component);
			if (_pins.Length != component.Width)
			{
				Debug.LogError("Wrong number of internal pins for this exploded view.");
			}
		}

		protected override void OnComponentUpdate(int newValue)
		{
			for (int i = 0; i < _pins.Length; i++)
			{
				int val = (newValue >> i) & 1;
				if (_pins[i] != null && VizSettings.CurrentSettings != null)
				{
					_pins[i].material = val == 0
						? VizSettings.CurrentSettings.PinOffMat
						: VizSettings.CurrentSettings.PinOnMat;
				}
			}
		}
	}
}