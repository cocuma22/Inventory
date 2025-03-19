using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //item data
    public string name;
    public int quantity;
    public Sprite sprite;
    public bool isEmpty = true;

    //item slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image image;

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

    public void UpdateQuantity()
    {
        quantityText.text = (int.Parse(quantityText.text) + 1).ToString();
    }
}
