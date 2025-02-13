using System;
using UnityEngine;

namespace Configuration
{
	public class SettingsManager : MonoBehaviour
	{
		public static VizSettings CurrentSettings;
		public VizSettings ActiveSettings;

		public void Awake()
		{
			CurrentSettings = ActiveSettings;
		}
	}
}