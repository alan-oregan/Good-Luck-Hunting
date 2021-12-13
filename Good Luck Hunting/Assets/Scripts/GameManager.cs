using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    public MusicManager music;
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
        music = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if there is no ammo left and all projectiles destroyed
        if (UI.getAmmo() + GameObject.FindGameObjectsWithTag("Projectile").Length == 0 && gameStarted) {
            gameOver();
        }

        if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("p")) && gameStarted) {
            pauseGame();
        }

        if (gameActive) {
            Cursor.lockState = CursorLockMode.Locked;
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
            UI.eneablePauseMenu(true);
            music.pauseAudio();
            Cursor.lockState = CursorLockMode.None;
        } else {
            gameActive = true;
            Time.timeScale = 1;
            UI.eneablePauseMenu(false);
            music.playAudio();
        }
    }

    public void destroyObjects(string tag) {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < objects.Length; i++) {
            Destroy(objects[i]);
        }
    }

    public void RestartGame() {
        UI.enableGameOverMenu(false);
        UI.resetUI();
        Time.timeScale = 1;
        gameActive = true;
        gameStarted = true;
        music.playGamePlayAudio();
    }

    public void StartGame() {
        UI.startGameText.gameObject.SetActive(false);
        this.RestartGame();
    }

    public void openGitHub()
    {
        Application.OpenURL("https://github.com/alan-oregan/Good-Luck-Hunting");
    }

    public void gameOver() {
        gameActive = false;
        gameStarted = false;
        destroyObjects("WhiteDuck");
        destroyObjects("OrangeDuck");
        destroyObjects("PondDuck");
        updateHighScore();
        UI.enableGameOverMenu(true);
        Cursor.lockState = CursorLockMode.None;
        music.playGameOverAudio();
    }
}
