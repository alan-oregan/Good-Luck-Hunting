using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variables
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    // Update Score
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score > 5) {
            gameOverText.gameObject.SetActive(true);
            GameManager.setGameActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
