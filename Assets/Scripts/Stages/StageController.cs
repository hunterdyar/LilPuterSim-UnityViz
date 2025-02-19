using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
	public static StageController Instance;
	public static Action<Stage> OnStageLoaded;
	public static Action OnLoadingStart;
	public static Action OnLoadingComplete;
    public List<Stage> _stages;

    public static object CurrentRoot => _currentRoot;
	private static object _currentRoot;
    public static Stage CurrentStage => _currentStage;
	[CanBeNull] private static Stage _currentStage;
	private Stack<Stage> _history = new Stack<Stage>();
	
	private void Awake()
	{
		if (Instance != null)
		{
			throw new Exception("There should only be one StageController in the scene");
		}
		else
		{
			Instance = this;
		}
	}

	void Start()
    {
        var defaultStage = _stages[0];
		LoadStage(defaultStage);
    }

    public void LoadStage(Stage newStage, [CanBeNull] object root = null)
    {
	    _currentRoot = root;
	    
	    if(_currentStage != null)
	    {
		    StartCoroutine(SwitchToScene(newStage));
		    _history.Push(newStage);
		    //if this stage extends, it's a child. If we are going back, remove.
	    }
	    else
	    {
		    _currentStage = newStage;
		    SceneManager.LoadScene(newStage.sceneName, LoadSceneMode.Additive);
		    //loading start. Loading complete.
		    _history.Push(newStage);
		    OnStageLoaded?.Invoke(newStage);
	    }
	    
    }

	private IEnumerator SwitchToScene(Stage nextStage)
	{
		OnLoadingStart?.Invoke();
	    yield return SceneManager.UnloadSceneAsync(_currentStage!.sceneName);
	    yield return SceneManager.LoadSceneAsync(nextStage.sceneName, LoadSceneMode.Additive);
	    _currentStage = nextStage;
	    OnLoadingComplete?.Invoke();
	    OnStageLoaded?.Invoke(nextStage);
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

	public bool CanGoBackInHistory()
	{
		return _history.Count > 1;
	}
}
