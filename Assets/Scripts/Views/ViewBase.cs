using LilPuter;
using UnityEngine;


public abstract class ViewBase<T,V> : MonoBehaviour where T : IObservable<V>
{
	private IObservable<V> _component;

	public virtual void SetComponent(T component)
	{
		_component = component;
		_component.Subscribe(OnComponentUpdate);
		OnComponentUpdate(_component.ReadValue());
	}

	protected abstract void OnComponentUpdate(V newValue);

	// Update is called once per frame
	protected virtual void OnDestroy()
	{
		_component.Unubscribe(OnComponentUpdate);
	}
}
