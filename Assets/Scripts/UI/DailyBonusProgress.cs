using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusProgress : MonoBehaviour
{
  
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private Image _progressBar;
    public void UpdateData(int num, bool available)
    {
        _progressText.text = $"{num}/{DailyBonusManager.Singleton.BonusesCount}";
        _progressBar.fillAmount = (float)num / DailyBonusManager.Singleton.BonusesCount;
    }
}
