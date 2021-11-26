using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variables
    private int score;
    private int ammo;
    public int startAmmo = 20;


    // getting text ui objects
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverTextHighScore;
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI pauseGame;
    public TextMeshProUGUI pauseGameHighScore;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI controlTips;



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
        this.resetUI();
    }


    // Update Score
    public void UpdateScore(int scoreChangeAmount){
        this.score += scoreChangeAmount;
    }


    public void UpdateAmmo(int ammoChangeAmount){

        if (this.ammo + ammoChangeAmount <= 0) {
            this.setAmmo(0);
        } else {
            this.ammo += ammoChangeAmount;
        }
    }

    public void resetUI() {
        //Start score with 0
        this.setScore(0);
        // Start with 20 ammo
        this.setAmmo(startAmmo);
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo + "/"+ startAmmo;
    }
}
