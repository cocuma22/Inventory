using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //item data
    public string name;
    public int quantity;
    public Sprite sprite;
    public bool isEmpty = true;
    public string itemDescription;

    //item slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image image;

    //item description slot
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionName;
    public TMP_Text itemDescriptionText;

    public GameObject frame;
    public bool isSelected;

    [SerializeField] private Inventory inventory;

    public void AddItem(string name, Sprite sprite, string itemDescription)
    {
        this.name = name;
        this.sprite = sprite;
        this.itemDescription = itemDescription;
        isEmpty = false;

        quantityText.text = "1";
        quantityText.enabled = true;

        image.enabled = true;
        image.sprite = sprite;
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
        inventory.DeselectAllSlots();
        frame.SetActive(true);
        isSelected = true;
        itemDescriptionName.text = name;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = sprite;
        itemDescriptionImage.enabled = true;

        if (itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.enabled = false;
        }
    }

    public void OnClick()
    {
        inventory.UseItem(itemDescriptionName.text);
    }

    public void AddQuantity()
    {
        quantityText.text = (int.Parse(quantityText.text) + 1).ToString();
    }

    public void RemoveQuantity()
    {
        quantityText.text = (int.Parse(quantityText.text) - 1).ToString();
    }
}
