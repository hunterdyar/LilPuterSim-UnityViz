using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public List<Stage> _stages;
	[CanBeNull] private Stage _currentStage;
	private Stack<Stage> _history = new Stack<Stage>();
	
    void Start()
    {
        var defaultStage = _stages[0];
		LoadStage(defaultStage);
    }

    private void LoadStage(Stage newStage)
    {
	    if(_currentStage != null)
	    {
		    StartCoroutine(SwitchToScene(newStage));
		    _history.Push(newStage);
		    //if this stage extends, it's a child. If we are going back, remove.
	    }
	    else
	    {
		    SceneManager.LoadScene(newStage.sceneName, LoadSceneMode.Additive);
		    _currentStage = newStage;
		    _history.Push(newStage);
	    }
    }

	private IEnumerator SwitchToScene(Stage nextStage)
	{
	    yield return SceneManager.UnloadSceneAsync(_currentStage!.sceneName);
	    yield return SceneManager.LoadSceneAsync(nextStage.sceneName, LoadSceneMode.Additive);
	    _currentStage = nextStage;
	}

	public bool GoBackInHistory()
	{
		if(_history.Count > 1)
		{
			_history.Pop();//remove current
			var previousStage = _history.Peek();//pop... and instantly re-push it when we call LoadStage.
			StartCoroutine(SwitchToScene(previousStage));
			return true;
		}
		return false;
	}
}
