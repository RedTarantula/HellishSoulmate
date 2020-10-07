using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniGameUI : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _timeText = default;
    [Header("Start Game")]
    [SerializeField]
    private GameObject _startGameCanvas = default;
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
    [SerializeField]
    private GameObject _replayGameButton = default;

    private MiniGameController _controller;
    private AudioSource _audioSource;

    private bool _hasStarted;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _controller = MiniGameController.Instance;
        _controller.OnEndGame += HandleEndGame;
        _endGameCanvas.SetActive(false);
        _hasStarted = false;
    }

    void Update()
    {
        if (!_hasStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _controller.StartGame();
            _startGameCanvas.SetActive(false);
            _hasStarted = true;
        }
        
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

    void HandleResetGame()
    {
        if (_controller.Souls > 120)
        {
            _controller.Souls -= 120;
            _endGameCanvas.SetActive(false);
            _hasStarted = false;
            _startGameCanvas.SetActive(true);
        }
    }

    IEnumerator EndCoroutine()
    {
        _endGameButton.SetActive(false);
        _endGameButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Bar"));

        _replayGameButton.SetActive(false);
        _replayGameButton.GetComponent<Button>().onClick.AddListener(()=>HandleResetGame());
        
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
        _replayGameButton.SetActive(true);
    }


}
