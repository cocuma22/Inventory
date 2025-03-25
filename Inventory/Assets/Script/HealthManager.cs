using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject[] lifeImages;
    public int currentLifes = 5;
    public int maxLifes = 5;
    [SerializeField] Warning _warningPanel;

    public void AddLife()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (!lifeImages[i].activeSelf)
            {
                lifeImages[i].SetActive(true);
                currentLifes++;

                return;
            }
        }
    }

    public void RemoveLife()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (lifeImages[i].activeSelf)
            {
                lifeImages[i].SetActive(false);
                currentLifes--;

                //when the player ends all its health, it dies
                if (currentLifes == 0)
                {
                    _warningPanel.SetWarning("You are dead");
                    Destroy(GameObject.Find("Player"));
                }

                return;
            }
        }
    }
}
