using System.Collections;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    private int frameNumber = 0;
    public float positionX, modPositionFall = 0.3f, waitTime = 0.2f;
    public bool ready = true;

    void Start()
    {
        positionX = gameObject.transform.position.x;
    }

    void Update()
    {
        if (ready == true )
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
            }
        }
    }

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;

    }
}
