using UnityEngine;

namespace DefaultNamespace
{
	public class MoveToStageTarget : MonoBehaviour
	{
		[SerializeField] private Stage _stage;
		
		public void MoveToStage()
		{
			StageController.Instance.LoadStage(_stage);
		}

		public void Select()
		{
			MoveToStage();
		}
	}
}