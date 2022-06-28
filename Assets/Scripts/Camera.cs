using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float distance, speed = 2, maxDistanceDown = 3, maxDistanceUp = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        distance = player.transform.position.y - gameObject.transform.position.y;

        if(distance >= maxDistanceDown)
        {
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0);  
        }
        else if (distance <= maxDistanceUp)
        {
            gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
       
    }
}
