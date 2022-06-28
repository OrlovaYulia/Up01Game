using UnityEngine;

public class SlopePlatform : MonoBehaviour
{
    public float slopeSpeed = 2f;
    private bool slopeLeft;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        slopeLeft = playerMovement.spriteRenderer.flipX;

        if (playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            if (slopeLeft == true)
            {
                collision.gameObject.transform.Translate(-slopeSpeed * Time.deltaTime, 0, 0);
            }

            if (slopeLeft == false)
            {
                collision.gameObject.transform.Translate(slopeSpeed * Time.deltaTime, 0, 0);
            }
        }

    }
}
