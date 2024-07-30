using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Note: This code has been used in previous projects, so it was written beforehand
[CreateAssetMenu(fileName = "GE_On", menuName = "ScriptableObjects/GameEvent/EmptyGameEvent")]
public class EmptyGameEvent : ScriptableObject
{
  private List<IEmptyGameEventListener> _listeners = new();

  public void Trigger()
  {
    // The list is copied because elements can remove themselves from the list during the loop
    var copiedList = new List<IEmptyGameEventListener>(_listeners);

    for (int i = copiedList.Count - 1; i >= 0; i--)
    {
      copiedList[i].OnEventTriggered();
    }

    _listeners = copiedList;
  }

  public IEmptyGameEventListener RegisterListener(IEmptyGameEventListener listener)
  {
    _listeners.Add(listener);
    return listener;
  }
  public void UnregisterListener(IEmptyGameEventListener listener)
  {
    _listeners.Remove(listener);
  }
}

#if UNITY_EDITOR

[CustomEditor(typeof(EmptyGameEvent))]
public class EmptyGameEventEditor : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();

    EmptyGameEvent assetGenerator = (EmptyGameEvent)target;

    if (GUILayout.Button("Trigger"))
    {
      assetGenerator.Trigger();
    }
  }
}

#endif
