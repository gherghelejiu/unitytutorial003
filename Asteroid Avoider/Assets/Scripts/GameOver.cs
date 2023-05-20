using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TMP_Text gameOverTextView;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private ScoreSystem scoreSystem;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        gameOverDisplay.gameObject.SetActive(true);

        gameOverTextView.text = $"Game Over, Your score is {scoreSystem.EndScore()}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
