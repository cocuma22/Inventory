using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] Material shieldEffectMaterial;
    private Material originalMaterial;
    [SerializeField] private int durationEffectInSeconds = 10;
    public bool isShieldEffectActive = false;
    [SerializeField] private Warning warningPanel;

    private void Start()
    {
        originalMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    public void ActivateProtection()
    {
        StartCoroutine(ActivateShieldEffect());
    }

    public IEnumerator ActivateShieldEffect()
    {

        isShieldEffectActive = true;
        this.gameObject.GetComponent<Renderer>().material = shieldEffectMaterial;
        yield return new WaitForSeconds(durationEffectInSeconds);
        this.gameObject.GetComponent<Renderer>().material = originalMaterial;
        isShieldEffectActive = false;
        warningPanel.SetWarning("Shield effect is over");

    }
}
