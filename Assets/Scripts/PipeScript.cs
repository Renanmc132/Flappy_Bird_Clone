using UnityEngine;

public class PipeScript : MonoBehaviour
{

    private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameControll.score++;
            player = collision.transform;
        }
    }

    private void Update()
    {
        if (player != null) { 
            if(player.transform.position.x > transform.position.x + 65)
            {
                Destroy(gameObject);
            }
        }
    }


}
