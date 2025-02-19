using LilPuter;
using TMPro;
using UnityEngine;

namespace Views
{
	public class RegisterView : ViewBase<Register,int>
	{
		public string regName;
		public TMP_Text _text;
		
		// Update is called once per frame
		protected override void OnComponentUpdate(int newValue)
		{
			_text.text = $"{regName}: {newValue}";
		}
	}
}