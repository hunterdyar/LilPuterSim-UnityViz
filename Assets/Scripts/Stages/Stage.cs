using UnityEngine;


[CreateAssetMenu(fileName = "Stage", menuName = "LilPuter/Stage", order = 1)]
public class Stage : ScriptableObject
{
	public string DisplayName => _displayName;
	[SerializeField] private string _displayName;
	public string sceneName;
	
	
}
