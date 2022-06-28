using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    public Transform rightBorder, leftBorder, platform;

    public void Update()
    { 
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        
        if (transform.position.x >= rightBorder.position.x)
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (transform.position.x <= leftBorder.position.x)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
        }
    }
}
