using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lvl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;

    void Start()
    {
        _title.text = $"Level {LevelManager.Instance.CurrentLvl}";
    }

    public void FinishLevel()
    {
        LevelManager.Instance.FinishLevel();
    }
   
}
