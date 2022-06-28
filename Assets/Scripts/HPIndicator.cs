using UnityEngine;

public class HPIndicator : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public int currentHP;
    public GameObject[] hearts;

    void Start()
    {
        
    }

    void Update()
    {
        currentHP = playerMovement.hp;
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i <= currentHP-1)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
