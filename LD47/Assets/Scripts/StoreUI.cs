using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreUI : MonoBehaviour
{
    
    [SerializeField]
    private Stats _stats = default;

    public GameObject voltaUI, bar;

    [Header("Tickets")]
    [SerializeField]
    private TextMeshProUGUI _ticketsAmount = default;
    [SerializeField]
    private TextMeshProUGUI _giftPriceText = default;
    [SerializeField]
    private TextMeshProUGUI _playGamePriceText = default;

    [Header("Gifts")]
    [SerializeField]
    private int _giftPrice = 120;
    [SerializeField]
    private Button _buyGiftButton = default;
    [SerializeField]
    public TextMeshProUGUI _isqueiroAmountText = default;
    public TextMeshProUGUI _florMurchaAmountText = default;
    public TextMeshProUGUI _lingerieAmountText = default;
    public TextMeshProUGUI _ursinhoAmountText = default;
    public TextMeshProUGUI _drinkAmountText = default;
    
    [Header("MiniGame")]
    [SerializeField]
    private int _playGamePrice = 120;
    [SerializeField]
    private Button _playGameButton = default;
    [Header("Close")]
    [SerializeField]
    private Button _closeButton = default;

    void Awake()
    {
        UpdateText();
    }

    void OnEnable()
    {
        _closeButton.onClick.AddListener(HandleClose);
        _buyGiftButton.onClick.AddListener(HandleBuyGift);
        _playGameButton.onClick.AddListener(HandlePlayGame);
    }

    void OnDisable()
    {
        _buyGiftButton.onClick.RemoveListener(HandleBuyGift);
        _playGameButton.onClick.RemoveListener(HandlePlayGame);
    }

    void HandleBuyGift()
    {
        if (_stats.tickets >= _giftPrice)
        {
            _stats.tickets -= _giftPrice;

            float rand = Random.Range(0f, 100f);
            if (rand < 15f) _stats.isqueiro += 1;
            else if (rand < 30f) _stats.florMurcha += 1;
            else if (rand < 45f) _stats.lingerie += 1;
            else if (rand < 60f) _stats.ursinho += 1;
            else _stats.drink += 1;
         
            UpdateText();
        }
    }

    void HandlePlayGame()
    {
        if (_stats.soul >= _playGamePrice)
        {
            _stats.soul -= _playGamePrice;
            SceneManager.LoadScene("MiniGame");
        }
    }

    void HandleClose()
    {
        bar.SetActive(true);
        voltaUI.SetActive(true);
        gameObject.SetActive(false);
    }

    void UpdateText()
    {
        _ticketsAmount.text = _stats.tickets.ToString();
        _giftPriceText.text = _giftPrice.ToString();
        _playGamePriceText.text = _playGamePrice.ToString();

        _isqueiroAmountText.text = _stats.isqueiro.ToString();
        _florMurchaAmountText.text = _stats.florMurcha.ToString();
        _lingerieAmountText.text = _stats.lingerie.ToString();
        _ursinhoAmountText.text = _stats.ursinho.ToString();
        _drinkAmountText.text = _stats.drink.ToString();
    }

}
