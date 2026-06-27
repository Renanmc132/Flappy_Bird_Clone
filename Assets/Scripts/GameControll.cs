using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControll : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void Awake()
    {

    }

    private void Update()
    {
        scoreText.text = "aobra: "+score;
    }

}
