using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //item data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    public bool isEmpty = true;
    public string itemDescription;

    //item slot
    [SerializeField] TMP_Text _quantityText;
    [SerializeField] Image _image;

    //item description slot
    [SerializeField] Image _itemDescriptionImage;
    [SerializeField] TMP_Text _itemDescriptionName;
    [SerializeField] TMP_Text _itemDescriptionText;

    //item selection
    public GameObject frame;
    public bool isSelected;

    [SerializeField] Inventory _inventory;

    public void AddItem(string itemName, Sprite sprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity += 1;
        this.sprite = sprite;
        this.itemDescription = itemDescription;
        isEmpty = false;

        _quantityText.text = this.quantity.ToString();
        _quantityText.enabled = true;

        _image.enabled = true;
        _image.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        _inventory.DeselectAllSlots();
        frame.SetActive(true);
        isSelected = true;
        _itemDescriptionName.text = itemName;
        _itemDescriptionText.text = itemDescription;
        _itemDescriptionImage.sprite = sprite;
        _itemDescriptionImage.enabled = true;

        if (_itemDescriptionImage.sprite == null)
        {
            _itemDescriptionImage.enabled = false;
        }
    }

    public void OnClick()
    {
        bool usable = _inventory.UseItem(_itemDescriptionName.text);
        _quantityText.text = quantity.ToString();
    }

    private void EmptySlot()
    {
        _quantityText.enabled = false;
        _image.enabled = false;

        _itemDescriptionText.text = "";
        _itemDescriptionName.text = "";
        _itemDescriptionImage.enabled = false;
    }

    public void AddQuantity()
    {
        quantity += 1;
        _quantityText.text = (int.Parse(_quantityText.text) + 1).ToString();
    }

    public void RemoveQuantity()
    {
        quantity -= 1;
        _quantityText.text = (int.Parse(_quantityText.text) - 1).ToString();
        if (quantity <= 0)
        {
            EmptySlot();
        }
    }
}
