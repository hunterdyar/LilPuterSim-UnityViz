using UnityEngine;
using UnityEngine.Serialization;

namespace Configuration
{
	[CreateAssetMenu(fileName = "VizSettings", menuName = "VizSettings", order = 0)]
	public class VizSettings : ScriptableObject
	{
		public Material PinOnMat => _pinOnMat;
		[SerializeField] private Material _pinOnMat;
		
		public Material PinOffMat => _pinOffMat;
		[SerializeField] private Material _pinOffMat;
	}
}