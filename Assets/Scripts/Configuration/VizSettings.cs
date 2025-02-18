using UnityEngine;
using UnityEngine.Serialization;

namespace Configuration
{
	[CreateAssetMenu(fileName = "VizSettings", menuName = "LilPuter/VizSettings", order = 0)]
	public class VizSettings : ScriptableObject
	{
		public static VizSettings CurrentSettings => GetCurrentSettings();

		private static VizSettings GetCurrentSettings()
		{
			if (_currentSettings == null)
			{
				_currentSettings = Resources.Load<VizSettings>("VizSettings");
			}
			return _currentSettings;
		}

		public void SetCurrentSettings(VizSettings newSettings)
		{
			_currentSettings = newSettings;
		}

		private static VizSettings _currentSettings;
		public Material PinOnMat => _pinOnMat;
		[SerializeField] private Material _pinOnMat;
		
		public Material PinOffMat => _pinOffMat;
		[SerializeField] private Material _pinOffMat;
	}
}