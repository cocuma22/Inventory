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
        shield,
        healer
    }

    public void UseItem()
    {
        if (itemType == ItemType.healer)
        {
            GameObject.Find("Health").GetComponent<HealthManager>().AddLife();
        }
        if (itemType == ItemType.shield)
        {
            GameObject.Find("Player").GetComponent<ShieldManager>().ActivateProtection();
        }
    }

}
