using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GetDailyBonusButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _dayNumber, _ticketsCount;

    [Header("View")]

    [SerializeField] private TextMeshProUGUI _dayNumberText;
    [SerializeField] private TextMeshProUGUI  _ticketsCountText;

    [SerializeField] private Color _interactable, _completed, _closed;



    private void OnValidate()
    {
        if (_dayNumberText) _dayNumberText.text = $"DAY {_dayNumber}";
        if (_ticketsCountText) _ticketsCountText.text = $"X{_ticketsCount}";
    }

   
    private void OnEnable()
    {
      
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    void OnClick()
    {
        DailyBonusManager.Singleton.ShowCongratulations(new DailyBonusViewData() { DayNumber = _dayNumber, TicketsCount = _ticketsCount });
    }

    public void SetInteractable()
    {
        _button.interactable = true;
        ColorBlock cBlock = _button.colors;
        cBlock.normalColor = _interactable;
        _button.colors = cBlock;
    }

    public void SetComplete()
    {
        _button.interactable = false;
        ColorBlock cBlock = _button.colors;
        cBlock.normalColor = _completed;
        cBlock.disabledColor = _completed;
        _button.colors = cBlock;
    }

    public void SetClosed()
    {
        _button.interactable = false;
        ColorBlock cBlock = _button.colors;
        cBlock.normalColor = _closed;
        _button.colors = cBlock;
    }

}
