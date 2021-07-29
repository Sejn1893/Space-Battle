using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }
    public void SetUpSingleton()
    {
        int numberOfSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }  
    public int GetScore()
    {
        return score;
    }    
    public void AddToScore(int ScoreValue)
    {
        score += ScoreValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
