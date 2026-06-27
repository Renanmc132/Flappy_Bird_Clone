using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControll : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;

    public GameObject pipeObject;
    private float timer;
    private float timeToSpawn = 3f;

    private void Awake()
    {

    }

    private void Update()
    {
        scoreText.text = "aobra: "+score;
    }

    private void SpawnPipe()
    {
        Instantiate(pipeObject, transform.position, transform.rotation);
    }

}
