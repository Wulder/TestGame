using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetDailyBonusButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _dayNumber, _ticketsCount;

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

    }


}
