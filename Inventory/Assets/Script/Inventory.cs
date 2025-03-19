using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] itemSlot;

    public void AddItem(string name, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].name == name)
            {
                itemSlot[i].UpdateQuantity();
                return;
            }

            if (itemSlot[i].isEmpty)
            {
                itemSlot[i].AddItem(name, sprite);
                return;
            }
        }
    }

}
