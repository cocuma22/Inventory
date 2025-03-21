using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public TMP_Text warningText;

    //the warning message is shown for 3 seconds, then it disappears
    public IEnumerator ShowWarning(string message)
    {
        warningText.text = message;
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
