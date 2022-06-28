using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    public float speed, getSpeed, minSpeed = 2, maxSpeed = 4, leftBorder, rightBorder;
    public bool switchDirection;

    void Start()
    {
        leftBorder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().leftBorderPosition;
        rightBorder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rightBorderPosition;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        gameObject.transform.Translate(getSpeed * Time.deltaTime, 0, 0);
        if (leftBorder == 0 || rightBorder == 0)
        {
            leftBorder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().leftBorderPosition;
            rightBorder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rightBorderPosition;
        }

        if (gameObject.transform.position.x > rightBorder)
            switchDirection = true;
        if (gameObject.transform.position.x < leftBorder)
            switchDirection = false;

        if (switchDirection == false)
            getSpeed = speed;
        else getSpeed = -speed;


    }
}
