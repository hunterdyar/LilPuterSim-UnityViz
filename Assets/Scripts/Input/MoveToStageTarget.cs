using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class MoveToStageTarget : MonoBehaviour, ISelectableViaCollider
	{
		[SerializeField] private Stage _stage;
		
		public void MoveToStage()
		{
			StageController.Instance.LoadStage(_stage, null);
		}

		public void Select()
		{
			MoveToStage();
		}
	}
}