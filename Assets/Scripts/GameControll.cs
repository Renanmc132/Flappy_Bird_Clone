using Unity.VisualScripting;
using UnityEngine;

public class GameControll : MonoBehaviour
{

    public GameObject scenario;
    public GameObject scenarioContinuation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            scenario.transform.localPosition += new Vector3(scenarioContinuation.transform.position.x + 65,0,0);
        }
    }



}
