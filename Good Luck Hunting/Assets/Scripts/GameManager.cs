using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    private static bool gameActive = false;

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
            setGameActive(false);
            UI.gameOverText.gameObject.SetActive(true);
        }

    }

    public void RestartGame() {
        GameManager.setGameActive(true);
        UI.gameOverText.gameObject.SetActive(false);
        UI.resetUI();
    }

    public void StartGame() {
        GameManager.setGameActive(true);
        UI.gameOverText.gameObject.SetActive(false);
        UI.startGameText.gameObject.SetActive(false);
        UI.resetUI();
    }
}
