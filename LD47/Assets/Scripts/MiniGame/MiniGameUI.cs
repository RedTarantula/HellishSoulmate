using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameUI : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _timeText = default;
    [SerializeField]
    private TextMeshProUGUI _scoreText = default;
    [Header("End Game")]
    [SerializeField]
    private GameObject _endGameCanvas = default;
    [SerializeField]
    private TextMeshProUGUI _endScoreText = default;

    private MiniGameController _controller;

    void Start()
    {
        _controller = MiniGameController.Instance;
        _controller.OnEndGame += HandleEndGame;
        _endGameCanvas.SetActive(false);
    }

    void Update()
    {
        _scoreText.text = _controller.Score.ToString();
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(_controller.GameTime);
        _timeText.text = string.Format("{0:D2}s", time.Seconds);
    }

    void HandleEndGame()
    {
        _endScoreText.text = _controller.Score.ToString();
        _endGameCanvas.SetActive(true);
    }

}
