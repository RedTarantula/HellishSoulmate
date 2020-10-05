using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameUI : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _timeText = default;
    [Header("End Game")]
    [SerializeField]
    private GameObject _endGameCanvas = default;
    [SerializeField]
    private TextMeshProUGUI _endScoreText = default;
    [SerializeField]
    private TextMeshProUGUI _endPresentsText = default;
    [SerializeField]
    private TextMeshProUGUI _endTicketsText = default;
    [SerializeField]
    private GameObject _endGameButton = default;

    private MiniGameController _controller;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _controller = MiniGameController.Instance;
        _controller.OnEndGame += HandleEndGame;
        _endGameCanvas.SetActive(false);
    }

    void Update()
    {
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(_controller.GameTime);
        _timeText.text = string.Format("{0:D2}s", time.Seconds);
    }

    void HandleEndGame()
    {
        StartCoroutine(EndCoroutine());
    }

    IEnumerator EndCoroutine()
    {
        _endGameButton.SetActive(false);
        
        _endScoreText.text = "";
        _endPresentsText.text = "";
        _endTicketsText.text = "";
        _endGameCanvas.SetActive(true);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= _controller.Score; i++)
        {
            _endScoreText.text = i.ToString();
            _audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= _controller.Presents; i++)
        {
            _endPresentsText.text = i.ToString();
            _audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= _controller.Tickets; i++)
        {
            _endTicketsText.text = i.ToString();
            _audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        _endGameButton.SetActive(true);
    }

}
