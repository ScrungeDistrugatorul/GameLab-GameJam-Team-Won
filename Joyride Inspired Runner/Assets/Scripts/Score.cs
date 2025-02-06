using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoreText;
    
    [HideInInspector] public int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            scoreText = GameObject.Find("MainScore").GetComponent<TextMeshProUGUI>();
            scoreText.text = score.ToString();
        }
        int distance = (int)player.transform.position.x * Random.Range(5,10);
        if (distance < int.Parse(scoreText.text)) return;
        scoreText.text = distance.ToString();
        score = distance;
    }
}
