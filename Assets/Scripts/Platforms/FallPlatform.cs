using System.Collections;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public GameObject player, particles;
    public float heightOfFall, fallSpeed = 5, positionX, modPositionFall = 0.3f, waitTime = 0.2f;
    private bool startFall = false, fall = false, ready = true;
    public int timeBeforeFall, frameNumber = 0, actualTimes = 0;

    void Start()
    {
        positionX = gameObject.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player");
        timeBeforeFall = Mathf.RoundToInt(Random.Range(0.51f, 3.49f));
        heightOfFall = Random.Range(heightOfFall / 2, heightOfFall * 1.2f);
    }

    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance <= heightOfFall)
        {
            startFall = true;
        }

        if(startFall == true)
        {
            StartFall();
        }
        if(fall == true)
        {
            gameObject.transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
        }
    }

    public void StartFall()
    {

        if (ready == true && actualTimes <= timeBeforeFall)
        {
            if (frameNumber == 0)
            {
                ready = false;
                gameObject.transform.position = new Vector3(positionX + modPositionFall, gameObject.transform.position.y, gameObject.transform.position.z);
                StartCoroutine(WaitTime());
                frameNumber++;
            }
            else if (frameNumber == 1)
            {
                ready = false;
                gameObject.transform.position = new Vector3(positionX, gameObject.transform.position.y, gameObject.transform.position.z);
                StartCoroutine(WaitTime());
                frameNumber++;
            }
            else if (frameNumber == 2)
            {
                ready = false;
                gameObject.transform.position = new Vector3(positionX - modPositionFall, gameObject.transform.position.y, gameObject.transform.position.z);
                StartCoroutine(WaitTime());
                frameNumber++;
            }

            else
            {
                ready = false;
                gameObject.transform.position = new Vector3(positionX, gameObject.transform.position.y, gameObject.transform.position.z);
                StartCoroutine(WaitTime());
                frameNumber = 0;
                actualTimes++;
            }
        }
        else if (actualTimes > timeBeforeFall)
        {
            gameObject.transform.position = new Vector3(positionX, gameObject.transform.position.y, gameObject.transform.position.z);
            fall = true;
        }
    }

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().damage = true;
        }
        Instantiate(particles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
