using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{

    [Header("Background")]
    public Transform cameraReference;
    public Transform firstGameScenario;
    public Transform secondGameScenario;
    private int distance = 65;

    [Header("Score")]
    public Image scoreUnity;
    public Image scoreDozen;
    public Image scoreHundreds;
    public static int score = 0;
    public Sprite[] numbers;

    [Header("Pipes")]
    public GameObject pipeObject;
    private float timer = 0;
    private float timeToSpawn = 5f;
    private float pipeDistance = 1;

    [Header("Start")]
    public Image startPage;
    public static bool isPlaying = false;

    private void Update()
    {

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnPipe();
            timer = timeToSpawn;
            pipeDistance++;
        }

        if(!isPlaying && Input.GetMouseButtonDown(0))
        {
            startPage.enabled = false;
               isPlaying = true;
        }



        InfiniteBackground();
        ScoreLogic();
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

    private void ScoreLogic()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            score++;
        if (isPlaying)
            {
                if (score < 9)
                {
                    scoreUnity.enabled = true;
                    scoreUnity.transform.localPosition = new Vector3(0, 390, 0);
                    scoreDozen.transform.localPosition = new Vector3(0, 390, 0);
                    scoreDozen.enabled = false;
                    scoreHundreds.transform.localPosition = new Vector3(0, 390, 0);
                    scoreHundreds.enabled = false;
                }
                else if (score > 9 && score < 100)
                {
                    scoreDozen.enabled = true;
                    scoreDozen.transform.localPosition = new Vector3(-52, 390, 0);
                    scoreUnity.transform.localPosition = new Vector3(52, 390, 0);
                }
                else if (score > 99)
                {
                    scoreDozen.transform.localPosition = new Vector3(0, 390, 0);
                    scoreUnity.transform.localPosition = new Vector3(105, 390, 0);
                    scoreHundreds.transform.localPosition = new Vector3(-105, 390, 0);
                    scoreHundreds.enabled = true;
                }

                scoreUnity.sprite = numbers[(score % 10)];
                scoreDozen.sprite = numbers[(score / 10) % 10];
                scoreHundreds.sprite = numbers[(score / 100)];
        }
        else
        {
            scoreHundreds.enabled = false;
            scoreDozen.enabled = false;
            scoreUnity.enabled = false;
        }
    }



}
