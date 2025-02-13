using LilPuter;
using UnityEngine;

namespace Views
{
	public class SystemInOutBusConnectionView : MonoBehaviour
	{
		[SerializeField] private ArrowVisual _arrow;
		public string InID => _inID;
		[SerializeField] private string _inID;
		public string OutID => _outID;
		[SerializeField] private string _outID;
		[SerializeField] private string displayName;

		private BusConnection _inConnection;
		private BusConnection _outConnection;
		public void SetConnection(BusConnection inConn,BusConnection outConn)
		{
			_inConnection = inConn;
			_outConnection = outConn;
		}

		public void Refresh()
		{
			if (_inConnection == null || _outConnection == null)
			{
				return;
			}
			if(_inConnection.Enabled && !_outConnection.Enabled)
			{
				_arrow.SetState(true,true);
			}else if (_outConnection.Enabled && !_inConnection.Enabled)
			{
				_arrow.SetState(true, false);
			}
			else
			{
				_arrow.SetState(false,false);
			}
			
		}
	}
}