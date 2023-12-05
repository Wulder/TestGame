using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DailyBonusManager : MonoBehaviour
{
    private static DailyBonusManager instance;
    public static DailyBonusManager Singleton => instance;

    [SerializeField] private GameObject _bonusGettingView, _background;
    [SerializeField] private BonusCongratulationsView _bonusCongratulationsView;

    private GameObject _currentPanel;
    private bool _isShowing;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);

        Hide();
    }

    void ShowPanel(GameObject panel)
    {
        if (_currentPanel != null) { _currentPanel.SetActive(false); }

        _currentPanel = panel;
        panel.SetActive(true);
    }

    public void Show()
    {
        if(_isShowing) return;
        _background.SetActive(true);
        _background.GetComponent<Image>().DOFade(.9f, .5f).SetEase(Ease.OutCirc);

        _isShowing = true;
        
    }
    public void Hide()
    {
        if(!_isShowing) return;

        _background.GetComponent<Image>().DOFade(0f, .5f).SetEase(Ease.OutCirc).OnComplete(() => { _background.SetActive(false); }); 
        HidePanel();
        _isShowing=false;
    }
    public void ShowCongratulations(DailyBonusViewData data)
    {
        _bonusCongratulationsView.SetData(data);
        ShowPanel(_bonusCongratulationsView.gameObject);
    }
    public void ShowGetting()
    {
        ShowPanel(_bonusGettingView);
    }
    public void HidePanel()
    {
        if (_currentPanel)
        {
            _currentPanel.SetActive(false);
            _currentPanel = null;
        }
    }
}
