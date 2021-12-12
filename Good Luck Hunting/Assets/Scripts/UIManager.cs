using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variables
    private int score;
    private int ammo;
    public int maxAmmo = 20;

    // getting text ui objects
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI leftControlTips;
    public TextMeshProUGUI rightControlTips;
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI pauseGame;
    public TextMeshProUGUI pauseGameHighScore;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverTextHighScore;

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


    /**
     * Enable control tips
     */
    public void eneableControlTips(bool value)
    {
        leftControlTips.gameObject.SetActive(value);
        rightControlTips.gameObject.SetActive(value);
    }

    /**
    * Enable start menu
    */
    public void enableStartMenu(bool value)
    {
        startGameText.gameObject.SetActive(value);
        this.eneableControlTips(value);
    }

    /**
    * Enable pause menu
    */
    public void eneablePauseMenu(bool value)
    {
        pauseGame.gameObject.SetActive(value);
        this.eneableControlTips(value);
    }

    /**
    * Enable game over menu
    */
    public void enableGameOverMenu(bool value)
    {
        gameOverText.gameObject.SetActive(value);
        this.eneableControlTips(value);
    }


    // Update Score
    public void UpdateScore(int scoreChangeAmount){
        this.score += scoreChangeAmount;
    }


    public void UpdateAmmo(int ammoChangeAmount){

        if (this.ammo + ammoChangeAmount <= 0 ) {
            this.setAmmo(0);
        } else if(this.ammo + ammoChangeAmount > maxAmmo) {
            this.setAmmo(maxAmmo);
        } else {
            this.ammo += ammoChangeAmount;
        }
    }

    public void resetUI() {
        //Start score with 0
        this.setScore(0);
        // Start with max ammo
        this.setAmmo(maxAmmo);
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo + "/"+ maxAmmo;
    }
}
