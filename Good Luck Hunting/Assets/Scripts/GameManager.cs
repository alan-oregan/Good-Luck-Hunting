using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    private static bool gameActive = false;
    private static bool gameStarted = false;

    public static bool isGameStarted()
    {
        return gameStarted;
    }

    public static void setGameStarted(bool newGameStarted)
    {
        gameStarted = newGameStarted;
    }

    private static int highScore = 0;

    public static int getHighScore()
    {
        return highScore;
    }

    public static void setHighScore(int newHighScore)
    {
        highScore = newHighScore;
    }

    public static bool isGameActive()
    {
        return gameActive;
    }

    public static void setGameActive(bool newGameActive)
    {
        gameActive = newGameActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if there is no ammo left and all projectiles destroyed
        if (UI.getAmmo() + GameObject.FindGameObjectsWithTag("Projectile").Length == 0) {
            gameOver();
        }

        if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("p")) && gameStarted) {
            pauseGame();
            Cursor.visible = true;
        }

        if (gameActive) {
            Cursor.visible = false;
        }
    }

    public void updateHighScore() {
        string highScoreString = "High Score: " + highScore;

        if (UI.getScore() > highScore) {
            highScore = UI.getScore();
            highScoreString = "New! High Score: " + highScore;
        }

        UI.gameOverTextHighScore.text = highScoreString;
        UI.pauseGameHighScore.text = highScoreString;

    }

    public void pauseGame() {
        if (gameActive) {
            gameActive = false;
            Time.timeScale = 0;
            updateHighScore();
            UI.pauseGame.gameObject.SetActive(true);
            UI.controlTips.gameObject.SetActive(true);
        } else {
            gameActive = true;
            Time.timeScale = 1;
            UI.pauseGame.gameObject.SetActive(false);
            UI.controlTips.gameObject.SetActive(false);
        }
    }

    public void destroyObjects(string tag) {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < objects.Length; i++) {
            Destroy(objects[i]);
        }
    }

    public void RestartGame() {
        UI.gameOverText.gameObject.SetActive(false);
        UI.controlTips.gameObject.SetActive(false);
        UI.resetUI();
        Time.timeScale = 1;
        gameActive = true;
        gameStarted = true;
    }

    public void StartGame() {
        UI.startGameText.gameObject.SetActive(false);
        RestartGame();
    }

    public void gameOver() {
        gameActive = false;
        gameStarted = false;
        destroyObjects("Capsule");
        updateHighScore();
        UI.gameOverText.gameObject.SetActive(true);
        UI.controlTips.gameObject.SetActive(true);
        Cursor.visible = true;
    }
}
