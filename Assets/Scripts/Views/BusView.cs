using System.Text;
using LilPuter;
using TMPro;
using UnityEngine;

public class BusView : ViewBase<Bus,int>
{
	public TMP_Text _text;
	private StringBuilder _sb = new StringBuilder();
	protected override void OnComponentUpdate(int newValue)
	{
		string active = GetActiveConnectionsLabel();
		_text.text = "Bus\n\n" + active + newValue.ToString();
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
