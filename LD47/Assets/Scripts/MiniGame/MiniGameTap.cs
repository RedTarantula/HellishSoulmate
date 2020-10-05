using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameTap : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _itemTap = default;
    private Image _itemImage;
    [SerializeField]
    private TextMeshProUGUI _tapsText = default;
    [SerializeField]
    private GameObject _tapEffectPrefab = default;
    [SerializeField]
    private GameObject _openEffectPrefab = default;

    private Animator _animator;

    private int _taps = 5;

    private int _current = 0;
    private bool _isActive;

    private MiniGameThrower _thrower;
    private MiniGameCollectObject _collect;
    private MiniGameController _controller;

    void Awake()
    {
        _controller = GameObject.FindObjectOfType<MiniGameController>();
        _animator = GetComponent<Animator>();
        _thrower = GameObject.FindObjectOfType<MiniGameThrower>();
        _itemImage = _itemTap.GetComponent<Image>();
        Disable();
    }

    void Start()
    {
        _controller.OnEndGame += HandleEndGame;
    }

    public void Construct(int taps, MiniGameCollectObject collect)
    {
        _collect = collect;
        _taps = taps;
        _current = 0;
        _itemTap.SetActive(true);
        _tapsText.gameObject.SetActive(true);
        _isActive = true;
        _thrower.IsActive = false;

        _itemImage.sprite = collect.GetComponentInChildren<SpriteRenderer>().sprite;
        _tapsText.text = _taps.ToString();
    }

    void Update()
    {
        if (!_isActive) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Tap();
        }
    }

    void LateUpdate()
    {
        if (!_isActive) _thrower.IsActive = true;
    }

    private void Tap()
    {
        _animator.SetTrigger("Tap");
        _current += 1;
        _tapsText.text = (_taps - _current).ToString();
        if (_current >= _taps)
        {
            _collect.OnCollect();
            // Instantiate(_openEffectPrefab, Vector2.zero, Quaternion.identity);
            Instantiate(_collect.OpenEffet, Vector2.zero, Quaternion.identity);
            Disable();
        }
        else
        {
            // Instantiate(_tapEffectPrefab, Vector2.zero, Quaternion.identity);
            Instantiate(_collect.TapEffet, Vector2.zero, Quaternion.identity);
        }
    }

    private void HandleEndGame()
    {
        Disable();
    }

    void Disable()
    {
        _isActive = false;
        _itemTap.SetActive(false);
        _tapsText.gameObject.SetActive(false);
    }

}
