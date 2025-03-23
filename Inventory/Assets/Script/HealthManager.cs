using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] lifeImages;
    //public bool isHealthFull = true;
    public int currentLifes = 5;
    public int maxLifes = 5;
    [SerializeField] private Warning warningPanel;

    public void AddLife()
    {
        //if (currentLifes != maxLifes)
        //{
        for (int i = 0; i < lifeImages.Length - 1; i++)
        {
            if (!lifeImages[i].activeSelf)
            {
                lifeImages[i].SetActive(true);
                currentLifes++;
                /*if (i == lifeImages.Length - 1)
                {
                    isHealthFull = true;
                }*/
                return;
            }
        }
        //}
    }

    public void RemoveLife()
    {
        for (int i = 0; i < lifeImages.Length - 1; i++)
        {
            if (lifeImages[i].activeSelf)
            {
                lifeImages[i].SetActive(false);
                currentLifes--;
                //if (i == lifeImages.Length - 1)
                if (currentLifes == 0)
                {
                    warningPanel.SetWarning("You are dead");
                    Destroy(GameObject.Find("Player"));
                }
                //isHealthFull = false;
                return;
            }
        }
    }
}
