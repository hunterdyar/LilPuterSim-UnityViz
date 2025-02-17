using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public List<Stage> _stages;
	[CanBeNull] private Stage _currentStage;
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
	    }

	    else
	    {
		    SceneManager.LoadScene(newStage.sceneName, LoadSceneMode.Additive);
		    _currentStage = newStage;
	    }
    }

	private IEnumerator SwitchToScene(Stage nextStage)
	{
	    yield return SceneManager.UnloadSceneAsync(_currentStage!.sceneName);
	    yield return SceneManager.LoadSceneAsync(nextStage.sceneName, LoadSceneMode.Additive);
	    _currentStage = nextStage;
	}
    
}
