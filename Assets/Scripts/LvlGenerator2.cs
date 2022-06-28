using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator2 : MonoBehaviour
{
    public GameObject[] platform;
    public GameObject lvlSpawner;
    public int levelLength, levelHeigth;
    public float hightCorrection = 2, specialPlatformChance = 80;
    [HideInInspector] public int platformNumer;
    public bool isSpawned = false;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        isSpawned = false;

        for (int i = 0; i <= (levelLength - 1); i++)
        {
            platformNumer = Mathf.RoundToInt(Random.Range(1, platform.Length));
            float platformChance = Random.Range(0f, 100f);
            if (platformChance > specialPlatformChance)
                Instantiate(platform[0], new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);
            else Instantiate(platform[platformNumer], new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);


            levelHeigth++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < 3 && isSpawned == false)
        {
            isSpawned = true;
            GameObject biomSpawner = Instantiate(lvlSpawner, new Vector3(0, levelHeigth * hightCorrection, 0), Quaternion.identity);
            biomSpawner.GetComponent<LvlGenerator2>().levelHeigth = levelHeigth;
        }
    }
}
