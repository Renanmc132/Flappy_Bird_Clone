using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private AudioSource pointAudio;
    void Start()
    {
        pointAudio = gameObject.AddComponent<AudioSource>();

        

        
    }
    private Transform player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameControll.score++;
            player = collision.transform;
            AudioClip clip = Resources.Load<AudioClip>("Audios/point");
            if (clip != null)
            {
                pointAudio.clip = clip;
                pointAudio.Play();
            }
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
