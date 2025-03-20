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

    //item slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image image;

    public GameObject frame;
    public bool isSelected;

    [SerializeField] private Inventory inventory;

    public void AddItem(string name, Sprite sprite)
    {
        this.name = name;
        this.sprite = sprite;
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
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventory.DeselectAllSlots();
        frame.SetActive(true);
        isSelected = true;
    }

    public void OnRightClick()
    {

    }

    public void UpdateQuantity()
    {
        quantityText.text = (int.Parse(quantityText.text) + 1).ToString();
    }
}
