using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string _itemName;
    [SerializeField] Sprite _sprite;

    [TextArea]
    [SerializeField] string _itemDescription;
    [SerializeField] Inventory _inventory;
    [SerializeField] Warning _warningPanel;

    //player collects items through collision but only if the inventory isn't full
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_inventory.isItemSlotFull)
            {
                _inventory.AddItem(_itemName, _sprite, _itemDescription);
                Destroy(gameObject);
            }
            else
            {
                _warningPanel.SetWarning("The inventory is full");
            }
        }
    }

}
