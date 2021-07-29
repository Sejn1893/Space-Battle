using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text ScoreText;
    private GameSession _gameSession;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = _gameSession.GetScore().ToString();
    }
}
