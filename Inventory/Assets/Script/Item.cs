using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;

    [TextArea]
    [SerializeField] private string itemDescription;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Warning warningPanel;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!inventory.isItemSlotFull)
            {
                inventory.AddItem(name, sprite, itemDescription);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("full");
                warningPanel.SetWarning("The inventory is full");
            }
        }
    }

}
