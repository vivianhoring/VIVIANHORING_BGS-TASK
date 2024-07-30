using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public interface IItem
{
    string Name { get; }
    Sprite Image { get; }
    ItemType ItemType { get; }
}
