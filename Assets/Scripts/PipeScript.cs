using UnityEngine;

public class PipeScript : MonoBehaviour
{

    private GameControll game;


    private void Awake()
    {
        game = GetComponent<GameControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            game.score++;
        }
    }



}
