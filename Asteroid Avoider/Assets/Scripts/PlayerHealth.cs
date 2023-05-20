using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private GameOver gameOverScript;

    public void Crash()
    {
        gameObject.SetActive(false);

        gameOverScript.EndGame();
    }
}
