using UnityEngine;

public class BackgroundControlSecond : MonoBehaviour
{

    private float distance = 65f;

    public Transform scenario1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scenario1.localPosition = new Vector3(scenario1.position.x + distance, 0, 0);
        }
    }


}
