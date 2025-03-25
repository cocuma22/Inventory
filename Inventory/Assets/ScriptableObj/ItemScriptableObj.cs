using UnityEngine;

[CreateAssetMenu]
public class ItemScriptableObj : ScriptableObject
{
    public ItemType itemType = new ItemType();

    public enum ItemType
    {
        none,
        Shield,
        Healer
    }

    public bool UseItem()
    {
        //healer is used only if the player's health isnt' full
        if (itemType == ItemType.Healer)
        {
            HealthManager healthManager = GameObject.Find("Health").GetComponent<HealthManager>();
            if (healthManager.currentLifes == healthManager.maxLifes)
            {
                GameObject.Find("Warning").GetComponent<Warning>().SetWarning("The health is full");
                return false;
            }
            else
            {
                healthManager.AddLife();
                return true;
            }

        }

        //shield effect is used only if there isn't another shield effect already active
        if (itemType == ItemType.Shield)
        {
            ShieldManager shieldManager = GameObject.Find("Player").GetComponent<ShieldManager>();
            if (shieldManager.isShieldEffectActive)
            {
                GameObject.Find("Warning").GetComponent<Warning>().SetWarning("Shield effect is already active");
                return false;
            }
            else
            {
                shieldManager.ActivateProtection();
                return true;
            }
        }
        return false;
    }

}
