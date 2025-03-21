using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] lifeImages;
    private bool isHealthFull = true;
    private Warning warningPanel;

    public void AddLife()
    {
        if (!isHealthFull)
        {
            for (int i = lifeImages.Length; i > 0; i--)
            {
                if (!lifeImages[i].activeSelf)
                {
                    lifeImages[i].SetActive(true);
                    if (i == 1)
                    {
                        isHealthFull = true;
                        StartCoroutine(warningPanel.ShowWarning("The health is full"));
                    }
                    return;
                }
            }
        }
        else
        {
            isHealthFull = true;
            StartCoroutine(warningPanel.ShowWarning("The health is full"));
        }
    }
}
