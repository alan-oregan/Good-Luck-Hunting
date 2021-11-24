using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Variables
    public int score;
    private float spawnRate = 1.0f;
    // public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    // Update Score
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        // scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
