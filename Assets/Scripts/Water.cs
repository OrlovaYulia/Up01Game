using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float startSpeed = 1, speedCorrection = 0.5f,speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        speed += Time.deltaTime * speedCorrection;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().hp = 0;
        }
    }
}
