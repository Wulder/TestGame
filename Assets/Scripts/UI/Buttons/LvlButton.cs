using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvlButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private Image _lockIcon;
    [SerializeField] private int _lvlNumber;
    public void Init(int Number)
    {
        
        _lvlNumber = Number;

        if(LevelManager.Instance.LastLvl >= Number || Number == 1)
        {
            _numberText.text = Number.ToString();
            _lockIcon.gameObject.SetActive(false);
        }
        else
        {
            _lockIcon.gameObject.SetActive(true);
            _numberText.gameObject.SetActive(false);
            GetComponent<Button>().interactable = false;
        }
    }

    public void StartLevel()
    {
        LevelManager.Instance.LoadLevel(_lvlNumber);
    }
    
}
