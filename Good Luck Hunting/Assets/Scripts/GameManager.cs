using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager UI;
    private static bool gameActive = true;

    public static bool isGameActive()
    {
        return gameActive;
    }

    public static void setGameActive(bool isGameActive)
    {
        gameActive = isGameActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update Score
    public void UpdateScore(int scoreToAdd){
        UI.UpdateScore(scoreToAdd);
    }

    public void RestartGame() {
        GameManager.setGameActive(true);
        UI.gameOverText.gameObject.SetActive(false);
        UI.setScore(0);
    }

    public void StartGame() {
        GameManager.setGameActive(true);
        UI.gameOverText.gameObject.SetActive(false);
        UI.disableStartUI();
        UI.setScore(0);
    }
}
