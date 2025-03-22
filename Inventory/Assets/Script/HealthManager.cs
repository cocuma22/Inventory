using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] lifeImages;
    private bool isHealthFull = true;
    [SerializeField] private Warning warningPanel;

    public void AddLife()
    {
        if (!isHealthFull)
        {
            for (int i = lifeImages.Length - 1; i >= 0; i--)
            {
                if (!lifeImages[i].activeSelf)
                {
                    lifeImages[i].SetActive(true);
                    return;
                }
                if (i == 0)
                {
                    isHealthFull = true;
                    StartCoroutine(warningPanel.ShowWarning("The health is full"));
                }
            }
        }
        else
        {
            isHealthFull = true;
            StartCoroutine(warningPanel.ShowWarning("The health is full"));
        }
    }

    public void RemoveLife()
    {
        for (int i = lifeImages.Length - 1; i >= 0; i--)
        {
            if (lifeImages[i].activeSelf)
            {
                lifeImages[i].SetActive(false);
                if (i == 0)
                {
                    StartCoroutine(warningPanel.ShowWarning("You are dead"));
                    Destroy(GameObject.Find("Player"));
                }
                isHealthFull = false;
                return;
            }
        }
    }
}
