using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    // Update is called once per frame
    void Update()
    {
        if(scorePlayer1 >= goalToWin || scorePlayer2 >= goalToWin)
        {
            Debug.Log("Game has won");
            SceneManager.LoadScene("Game Over");
        }
    }

    private void FixedUpdate()
    {
        Text uiScorePlayer1 = scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = scorePlayer1.ToString();

        Text uiScorePlayer2 = scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        scorePlayer1++;
    }

    public void GoalPlayer2()
    {
        scorePlayer2++;
    }
}
