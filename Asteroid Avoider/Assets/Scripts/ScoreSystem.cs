using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private float scoreMultiplier;
    [SerializeField] private TMP_Text scoreTextView;

    private float score;
    private bool shouldCount = true;

    // Update is called once per frame
    void Update()
    {
        if (!shouldCount) { return; }

        score += scoreMultiplier * Time.deltaTime;
        int scoreInt = Mathf.FloorToInt(score);
        scoreTextView.text = scoreInt.ToString();
    }

    public int EndScore()
    {
        shouldCount = false;
        scoreTextView.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
}
