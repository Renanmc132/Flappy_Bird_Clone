using UnityEngine;

public class BackgroundControlFirst : MonoBehaviour
{
    private float distance = 65f;

    public Transform scenario2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scenario2.localPosition = new Vector3(scenario2.position.x + distance, 0, 0);
        }
    }
}
