using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

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
        this.quantity += 1;
        this.sprite = sprite;
        this.itemDescription = itemDescription;
        isEmpty = false;

        quantityText.text = this.quantity.ToString();
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
        bool usable = inventory.UseItem(itemDescriptionName.text);
        quantityText.text = quantity.ToString();
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        image.enabled = false;

        itemDescriptionText.text = "";
        itemDescriptionName.text = "";
        itemDescriptionImage.enabled = false;
    }

    public void AddQuantity()
    {
        quantity += 1;
        quantityText.text = (int.Parse(quantityText.text) + 1).ToString();
    }

    public void RemoveQuantity()
    {
        quantity -= 1;
        quantityText.text = (int.Parse(quantityText.text) - 1).ToString();
        if (quantity <= 0)
        {
            EmptySlot();
        }
    }
}
