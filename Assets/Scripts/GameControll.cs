using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControll : MonoBehaviour
{

    [Header("Background")]
    public Transform cameraReference;
    public Transform firstGameScenario;
    public Transform secondGameScenario;
    private int distance = 65;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public static int score = 0;

    [Header("Pipes")]
    public GameObject pipeObject;
    private float timer = 0;
    private float timeToSpawn = 5f;
    private float pipeDistance = 1;


    private void Update()
    {
        scoreText.text = ""+score;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnPipe();
            timer = timeToSpawn;
            pipeDistance++;
        }

        

    }

    private void SpawnPipe()
    {
        float Xpos = 30;
        float Ypos = UnityEngine.Random.Range(10,-3);
        Instantiate(pipeObject, new Vector2(Xpos * pipeDistance, Ypos), transform.rotation);
    }

    private void InfiniteBackground()
    {
        if (cameraReference.position.x > (firstGameScenario.position.x + distance))
        {
            firstGameScenario.localPosition = new Vector3(firstGameScenario.position.x + distance * 2, 0, 0);
        }

        if (cameraReference.position.x > (secondGameScenario.position.x + distance))
        {
            secondGameScenario.localPosition = new Vector3(secondGameScenario.position.x + distance * 2, 0, 0);
        }
    }





}
