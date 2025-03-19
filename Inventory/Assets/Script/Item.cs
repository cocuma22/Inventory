using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string name;
    //[SerializeField] private int quantity;
    [SerializeField] private Material material;
    [SerializeField] private Inventory inventory;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory.AddItem(name, material);
            Destroy(gameObject);
        }
    }
}
