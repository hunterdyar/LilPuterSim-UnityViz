using System;
using System.Text;
using LilPuter;
using TMPro;
using UnityEngine;
using Views;

public class BusView : ViewBase<Bus,Bus>
{
	public TMP_Text _text;
	private StringBuilder _sb = new StringBuilder();
	private BusConnectionView[] _connectionViews;

	private void Awake()
	{
		_connectionViews = GetComponentsInChildren<BusConnectionView>();
	}

	public override void SetComponent(Bus component)
	{
		base.SetComponent(component);
		InitConnections();
	}

	private void InitConnections()
	{
		foreach (var connectionView in _connectionViews)
		{
			var c = _component.Connections.Find(x => x.Name == connectionView.ConnectionName);
			if (c != null)
			{
				connectionView.SetConnection(c);
			}
		}
	}

	protected override void OnComponentUpdate(Bus bus)
	{
		string active = GetActiveConnectionsLabel();
		_text.text = "Bus\n\n" + active + bus.Value.ToString();
		
		foreach (var connectionView in _connectionViews)
		{
			connectionView.Refresh();
		}
	}

	private string GetActiveConnectionsLabel()
	{
		_sb.Clear();
		foreach (var conn in _component.Connections)
		{
			if (!conn.Enabled)
			{
				continue;
			}
			_sb.Append(conn.Name);
			_sb.Append(' ');
		}
		return _sb.ToString();
	}
}
