using UnityEngine;

public class PipeScript : MonoBehaviour
{

    public GameControll game;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            game.score++;
        }
    }



}
