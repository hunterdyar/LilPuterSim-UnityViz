using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class CounterView : ViewBase<Counter, int>
	{
		[SerializeField] private TMP_Text _text;
		protected override void OnComponentUpdate(int newValue)
		{
			_text.text = newValue.ToString();
		}
	}
}