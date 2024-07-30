using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Note: This code has been used in previous projects, so it was written beforehand, I just adapted for what I needed here
[CreateAssetMenu(fileName = "GE_On", menuName = "ScriptableObjects/GameEvent/ItemGameEvent")]
public class ItemGameEvent : ScriptableObject
{
    private List<IGameEventListener<Item>> _listeners = new();

  public void Trigger(Item item)
  {
    // The list is copied because elements can remove themselves from the list during the loop
    var copiedList = new List<IGameEventListener<Item>>(_listeners);

    for (int i = copiedList.Count - 1; i >= 0; i--)
    {
      copiedList[i].OnEventTriggered(item);
    }

    _listeners = copiedList;
  }

  public IGameEventListener<Item> RegisterListener(IGameEventListener<Item> listener)
  {
    _listeners.Add(listener);
    return listener;
  }
  public void UnregisterListener(IGameEventListener<Item> listener)
  {
    _listeners.Remove(listener);
  }
}
