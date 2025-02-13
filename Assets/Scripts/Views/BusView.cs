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
	private SingleBusConnectionView[] _singleConnectionViews = Array.Empty<SingleBusConnectionView>();
	private SystemInOutBusConnectionView[] _sysConnectioonViews = Array.Empty<SystemInOutBusConnectionView>();

	public override void SetComponent(Bus component)
	{
		base.SetComponent(component);
		InitConnections();
	}

	private void InitConnections()
	{
		_singleConnectionViews = GetComponentsInChildren<SingleBusConnectionView>();
		_sysConnectioonViews = GetComponentsInChildren<SystemInOutBusConnectionView>();
		foreach (var connectionView in _singleConnectionViews)
		{
			var c = _component.Connections.Find(x => x.Name == connectionView.ConnectionName);
			if (c != null)
			{
				connectionView.SetConnection(c);
			}
		}

		foreach (var sioView in _sysConnectioonViews)
		{
			var inc = _component.Connections.Find(x => x.Name == sioView.InID);
			var outc = _component.Connections.Find(x => x.Name == sioView.OutID);
			if (inc != null && outc != null)
			{
				sioView.SetConnection(inc, outc);
			}
		}
	}

	protected override void OnComponentUpdate(Bus bus)
	{
		string active = GetActiveConnectionsLabel();
		_text.text = "Bus\n\n" + active + bus.Value.ToString();
		
		foreach (var connectionView in _singleConnectionViews)
		{
			connectionView.Refresh();
		}

		foreach (var connectionView in _sysConnectioonViews)
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
