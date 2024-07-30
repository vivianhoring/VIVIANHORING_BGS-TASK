using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent<T> : ScriptableObject
{
  private List<IGameEventListener<T>> _listeners = new();

  public void Trigger(T data)
  {
    // The list is copied because elements can remove themselves from the list during the loop
    var copiedList = new List<IGameEventListener<T>>(_listeners);

    for (int i = copiedList.Count - 1; i >= 0; i--)
    {
      copiedList[i].OnEventTriggered(data);
    }

    _listeners = copiedList;
  }

  public IGameEventListener<T> RegisterListener(IGameEventListener<T> listener)
  {
    _listeners.Add(listener);
    return listener;
  }
  public void UnregisterListener(IGameEventListener<T> listener)
  {
    _listeners.Remove(listener);
  }
}