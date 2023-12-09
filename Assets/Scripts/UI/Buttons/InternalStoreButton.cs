using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InternalStoreButton : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private string _key;
    [SerializeField] private int _value;
    [SerializeField] private int _lvlLimitation;
    

    [Header("View")]
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _lvlLimitationText;
    [SerializeField] private Image _imagePreview;
    [SerializeField] private Sprite _icon, _lockIcon;

    [SerializeField] private GameObject _priceContent, _purchasedContent;

    private bool _isPurchased;

    private Button _button;

    private void OnValidate()
    {
        _nameText.text = _name;
        _priceText.text = _price.ToString();
        _lvlLimitationText.text = $"LV. {_lvlLimitation}";
    }
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Buy);
        UserData.Instance.OnDataUpdated += UpdateState;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Buy);
        UserData.Instance.OnDataUpdated -= UpdateState;
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _button.interactable = false;
        UserData.Instance.Read<int>(UserData.Instance.Keys.Tickets, out int ticketsCount);
        int result = 0;
        if (UserData.Instance.Read<int>(_key, out result))
        {
            if (result > 0)
            {
                _isPurchased = true;
            }
        }

        _imagePreview.sprite = _icon;

        if (_isPurchased)
        {
            
            _purchasedContent.SetActive(true);
            _priceContent.SetActive(false);
            _lvlLimitationText.gameObject.SetActive(false);
            return;
        }
        else if(ticketsCount >= _price)
        {
            _purchasedContent.SetActive(false);
            _priceContent.SetActive(true);
            _button.interactable = true;
        }

        bool isLvlLock = LevelManager.Instance.LastLvl < _lvlLimitation;

        if(isLvlLock)
        {
            _lvlLimitationText.gameObject.SetActive(true);
            _lvlLimitationText.text = $"LV. {_lvlLimitation}";
            _imagePreview.sprite = _lockIcon;
            _button.interactable = false;
        }
        else
        {
            _lvlLimitationText.gameObject.SetActive(false);
        }
    }

    [ContextMenu("Buy")]
    private void Buy()
    {
        InternalStoreLogic.Instance.Buy<int>(_price, _key, _value);
        Init();
    }

    void UpdateState(string key)
    {
        var keys = UserData.Instance.Keys;

        if (key == keys.Tickets)
            Init();
            
    }

}
