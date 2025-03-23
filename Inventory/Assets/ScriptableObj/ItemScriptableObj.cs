using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemScriptableObj : ScriptableObject
{
    public ItemType itemType = new ItemType();

    public bool isOneShotEffect;

    public int durationEffectInSeconds;

    public enum ItemType
    {
        none,
        Shield,
        Healer
    }

    public void UseItem()
    {
        Debug.Log("nel SO itemType = " + itemType.ToString());
        if (itemType == ItemType.Healer)
        {
            GameObject.Find("Health").GetComponent<HealthManager>().AddLife();
        }
        if (itemType == ItemType.Shield)
        {
            GameObject.Find("Player").GetComponent<ShieldManager>().ActivateProtection();
        }
    }

}
