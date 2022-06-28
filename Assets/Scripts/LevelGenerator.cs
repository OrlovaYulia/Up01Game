using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platform;
    public GameObject[] biomPlatform;
    private int levelLength, levelHeigth;
    public float hightCorrection = 2, specialPlatformChance = 80;
    private bool isSpawned = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i <= (levelLength - 1); i++)
        {
                float platformChance = Random.Range(0f, 100f);
                if (platformChance > specialPlatformChance)
                Instantiate(platform[0], new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);
                else
                Instantiate(platform[1], new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);
               
            
                levelHeigth++;
        }
    }

    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, player.transform.position) < 10 && isSpawned == false)
        {
            GameObject biomSpawner = Instantiate(biomPlatform[Mathf.RoundToInt(Random.Range(0, biomPlatform.Length))], new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);
            biomSpawner.GetComponent<LevelGenerator>().levelHeigth = levelHeigth;
            isSpawned = true;
        }
    }
}
