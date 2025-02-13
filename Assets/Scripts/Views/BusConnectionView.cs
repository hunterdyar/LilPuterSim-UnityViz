﻿using Configuration;
using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class BusConnectionView : MonoBehaviour
	{
		[SerializeField] TMP_Text _text;
		[SerializeField] private bool _inDirIsRight = true;
		public string ConnectionName => _connectionName;
		[SerializeField] string _connectionName;
		[SerializeField] string _displayName;
		private BusConnection _busConnection;
		[SerializeField] private MeshRenderer _renderer;
		public void SetConnection(BusConnection connection)
		{
			_busConnection = connection;
		}

		public void Refresh()
		{
			if (_busConnection == null)
			{
				return;
			}
			
			_renderer.material = _busConnection.Enabled ? SettingsManager.CurrentSettings._pinOnMat : SettingsManager.CurrentSettings._pinOffMat;
			//tick
			if (_busConnection.Enabled)
			{
				if (_inDirIsRight)
				{
					_text.text = $"-{_displayName}->";
				}
				else
				{
					_text.text = $"<-{_displayName}-";
				}
			}
			else
			{
				_text.text = $"-{_displayName}-";
			}
		}
	}
}