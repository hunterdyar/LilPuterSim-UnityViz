using LilPuter;
using TMPro;
using UnityEngine;

public class BusView : ViewBase<Bus,int>
{
	public TMP_Text _text;

	protected override void OnComponentUpdate(int newValue)
	{
		_text.text = "Bus\n" + newValue.ToString();
	}
}
