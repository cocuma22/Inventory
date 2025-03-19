using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public void AddItem(string name, Material material)
    {
        Debug.Log("itemName = " + name + " material = " + material);
    }

}
