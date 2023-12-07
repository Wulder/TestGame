using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _menuPanel;


    public void Show()
    {
        _background.SetActive(true);
        _background.GetComponent<Image>().DOFade(.9f, .5f).SetEase(Ease.OutCirc).OnComplete(() => { _menuPanel.SetActive(true); });
    }

    public void Hide()
    { 
        _menuPanel.SetActive(false); 
    _background.GetComponent<Image>().DOFade(0f, .5f).SetEase(Ease.OutCirc).OnComplete(() => { _background.SetActive(false); });
    }


}
