using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
public class InventoryImage : MonoBehaviour
{
    [SerializeField]
    int _place; public int Place => _place;
    [SerializeField]
    Image _backgroundImage; public Image BackgroundImage => _backgroundImage;
    [SerializeField]
    public Sprite ItemSprite {get; set;}
}
