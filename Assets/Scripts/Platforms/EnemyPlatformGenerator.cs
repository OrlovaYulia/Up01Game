using UnityEngine;

public class EnemyPlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms;
    public int nr;

    public void Awake()
    {
        nr = Mathf.RoundToInt(Random.Range(-0.49f, platforms.Length - 0.51f));
    }

    void Start()
    {
        platforms[nr].SetActive(true);
    }
}
