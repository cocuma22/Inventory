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
    public TMP_Text warningText;
    [SerializeField] private GameObject warningPanel;

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
                StartCoroutine(ShowWarning("The inventory is full"));
            }
        }
    }

    //the warning message is shown for 3 seconds, then it disappears
    IEnumerator ShowWarning(string message)
    {
        warningText.text = message;
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        warningPanel.SetActive(false);
    }

}
