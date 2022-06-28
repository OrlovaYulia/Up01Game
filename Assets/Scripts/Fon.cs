using UnityEngine;

public class Fon : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(0, player.transform.position.y * -0.1f, 0);
    }
}
