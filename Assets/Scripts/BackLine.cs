using UnityEngine;

public class BackLine : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().hp = 0;
        }
        else if (collision.gameObject.tag != "Water")
        {
            Destroy(collision.gameObject);
        }
    }
}
