using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField] private TMP_Text warningText;

    public void SetWarning(string message)
    {
        StartCoroutine(ShowWarning(message));
    }

    //the warning message is shown for 3 seconds, then it disappears
    private IEnumerator ShowWarning(string message)
    {
        warningText.text = message;
        this.gameObject.GetComponent<Image>().enabled = true;
        warningText.enabled = true;
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<Image>().enabled = false;
        warningText.enabled = false;
    }
}
