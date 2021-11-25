using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variables
    private int score;
    private int ammo;

    // getting text ui objects
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI ammoText;



    public int getAmmo()
    {
        return this.ammo;
    }


    public void setAmmo(int ammo)
    {
        this.ammo = ammo;
    }


    public int getScore()
    {
        return this.score;
    }


    public void setScore(int score)
    {
        this.score = score;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Start score with 0
        setScore(0);
        // Start with 20 ammo
        setAmmo(20);
    }


    // Update Score
    public void UpdateScore(int scoreChangeAmount){
        score += scoreChangeAmount;
    }

    public void UpdateAmmo(int ammoChangeAmount){
        ammo += ammoChangeAmount;

        if (ammo <= 0) {
            gameOverText.gameObject.SetActive(true);
            GameManager.setGameActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo;
    }
}
