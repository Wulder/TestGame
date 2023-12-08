using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GetDailyBonusButton : MonoBehaviour
{

    public UnityEvent OnClickEvent;
    [SerializeField] private Button _button;
    [SerializeField] private int _dayNumber, _ticketsCount;

    public int DayNumber => _dayNumber;
    public int TicketsCount => _ticketsCount;

    [Header("View")]

    [SerializeField] private TextMeshProUGUI _dayNumberText;
    [SerializeField] private TextMeshProUGUI _ticketsCountText;

    [SerializeField] private Color _interactable, _completed, _closed;



    private void OnValidate()
    {
        if (_dayNumberText) _dayNumberText.text = $"DAY {_dayNumber}";
        if (_ticketsCountText) _ticketsCountText.text = $"X{_ticketsCount}";
    }


    public void OnEnable()
    {

        _button.onClick.AddListener(OnClick);
     
        _button.onClick.AddListener(OnClickEvent.Invoke);
        
    }

    public void OnDisable()
    {
         
        _button.onClick.RemoveListener(OnClick);
        
        _button.onClick.RemoveListener(OnClickEvent.Invoke);
        
    }

    
    void OnClick()
    {

        DailyBonusManager.Singleton.GetBonus(new DailyBonusViewData() { DayNumber = _dayNumber, TicketsCount = _ticketsCount });
    }

   protected virtual void SetInteractable()
    {
        _button.interactable = true;
        ColorBlock cBlock = _button.colors;
        cBlock.normalColor = _interactable;
        _button.colors = cBlock;
    }

   protected virtual void SetComplete()
    {
        _button.interactable = false;
        ColorBlock cBlock = _button.colors;
        cBlock.disabledColor = _completed;
        _button.colors = cBlock;
        
    }

    protected virtual void SetClosed()
    {
        _button.interactable = false;
        ColorBlock cBlock = _button.colors;
        cBlock.disabledColor = _closed;
        _button.colors = cBlock;
    }

    public void SetStatus(DailyBonusButtonStatus status)
    {
        switch (status)
        {
            case DailyBonusButtonStatus.Interactable:
                {
                    SetInteractable();
                    break;
                }
            case DailyBonusButtonStatus.Complete:
                {
                    SetComplete();
                    break;
                }
            case DailyBonusButtonStatus.Closed:
                {
                    SetClosed();
                    break;
                }
        }
    }

}
public enum DailyBonusButtonStatus
{
    Interactable,
    Complete,
    Closed
}
