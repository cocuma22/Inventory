using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] itemSlot;
    public ItemScriptableObj[] items;
    public bool isItemSlotFull = false;
    public GameObject applyEffectBtn;

    public void AddItem(string name, Sprite sprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].name == name)
            {
                itemSlot[i].AddQuantity();
                return;
            }

            if (itemSlot[i].isEmpty)
            {
                itemSlot[i].AddItem(name, sprite, itemDescription);

                //check if the inventory is completely full
                if (i == itemSlot.Length - 1)
                {
                    isItemSlotFull = true;
                }

                return;
            }
        }
    }

    public void UseItem(string itemType)
    {
        Debug.Log("nell'inventario l'itemType è " + itemType);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemType.ToString() == itemType)
            {
                items[i].UseItem();
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].frame.SetActive(false);
            itemSlot[i].isSelected = false;
        }
    }

}
