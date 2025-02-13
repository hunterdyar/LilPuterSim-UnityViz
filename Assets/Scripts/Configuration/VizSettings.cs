using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "VizSettings", menuName = "VizSettings", order = 0)]
	public class VizSettings : ScriptableObject
	{
		public Material _pinOnMat;
		public Material _pinOffMat;
	}
}