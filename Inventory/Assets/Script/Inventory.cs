using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] ItemSlot[] _itemSlot;
    [SerializeField] ItemScriptableObj[] _items;
    public bool isItemSlotFull = false;
    public GameObject applyEffectBtn;

    public void AddItem(string itemName, Sprite sprite, string itemDescription)
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            //update item quantity
            if (_itemSlot[i].itemName == itemName)
            {
                _itemSlot[i].AddQuantity();
                return;
            }

            if (_itemSlot[i].isEmpty)
            {
                _itemSlot[i].AddItem(itemName, sprite, itemDescription);

                //check if the inventory is completely full
                if (i == _itemSlot.Length - 1)
                {
                    isItemSlotFull = true;
                }

                return;
            }
        }
    }

    public bool UseItem(string itemType)
    {
        bool usable = false;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].itemType.ToString() == itemType)
            {
                usable = _items[i].UseItem();
            }
        }

        if (usable)
        {
            for (int i = 0; i < _itemSlot.Length; i++)
            {
                if (_itemSlot[i].itemName == itemType)
                {
                    _itemSlot[i].RemoveQuantity();
                    return usable;
                }
            }
        }
        return false;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            _itemSlot[i].frame.SetActive(false);
            _itemSlot[i].isSelected = false;
        }
    }

}
