using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BonusCongratulationsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayNumberText, _ticketsCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(DailyBonusViewData data)
    {
        _dayNumberText.text = $"DAY{data.DayNumber}";
        _ticketsCountText.text = $"X{data.TicketsCount}";
    }


  

   
}

public struct DailyBonusViewData
{
    public int DayNumber, TicketsCount;
}
