using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] Material _shieldEffectMaterial;
    Material _originalMaterial;
    [SerializeField] int _durationEffectInSeconds = 10;
    public bool isShieldEffectActive = false;
    [SerializeField] Warning _warningPanel;

    private void Start()
    {
        _originalMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    public void ActivateProtection()
    {
        StartCoroutine(ActivateShieldEffect());
    }

    //When the shield effect is active, the player temporarily changes its color
    public IEnumerator ActivateShieldEffect()
    {
        isShieldEffectActive = true;
        this.gameObject.GetComponent<Renderer>().material = _shieldEffectMaterial;

        yield return new WaitForSeconds(_durationEffectInSeconds);

        this.gameObject.GetComponent<Renderer>().material = _originalMaterial;
        isShieldEffectActive = false;
        _warningPanel.SetWarning("Shield effect is over");

    }
}
