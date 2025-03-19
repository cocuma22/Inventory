using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Inventory inventory;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory.AddItem(name, sprite);
            Destroy(gameObject);
        }
    }
}
