using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentData : MonoBehaviour
{
    [SerializeField]
    Image _weaponEquipmentImage;
    [SerializeField]
    Image _helmetEquipmentImage;
    [SerializeField]
    Image _armorEquipmentImage;
    [SerializeField]
    Image _bootsEquipmentImage;

    public void UpdateUI(List<Item> equippedItems)
    {
        for (int i = 0; i< equippedItems.Count; i++)
        {
            var equippedItemType = equippedItems[i].ItemDetails.ItemType;
            if (equippedItemType is ItemType.Weapon) _weaponEquipmentImage.sprite = equippedItems[i].ItemDetails.Image;
            else if (equippedItemType is ItemType.Helmet) _helmetEquipmentImage.sprite = equippedItems[i].ItemDetails.Image;
            else if (equippedItemType is ItemType.Armor) _armorEquipmentImage.sprite = equippedItems[i].ItemDetails.Image;
            else if (equippedItemType is ItemType.Boots) _bootsEquipmentImage.sprite = equippedItems[i].ItemDetails.Image;
        }
    }
}
