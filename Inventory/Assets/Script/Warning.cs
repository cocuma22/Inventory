using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField] TMP_Text _warningText;
    [SerializeField] int _timerInSeconds = 3;

    public void SetWarning(string message)
    {
        StartCoroutine(ShowWarning(message));
    }

    //the warning message is shown for 'timerInSeconds' seconds, then it disappears
    private IEnumerator ShowWarning(string message)
    {
        _warningText.text = message;
        this.gameObject.GetComponent<Image>().enabled = true;
        _warningText.enabled = true;

        yield return new WaitForSeconds(_timerInSeconds);

        this.gameObject.GetComponent<Image>().enabled = false;
        _warningText.enabled = false;
    }
}
