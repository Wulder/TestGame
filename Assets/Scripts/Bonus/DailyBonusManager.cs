using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;


public class DailyBonusManager : MonoBehaviour
{
    public event Action<int, bool> OnGetBonusAvailableInfo;

    private static DailyBonusManager instance;
    public static DailyBonusManager Singleton => instance;

    [SerializeField] private GameObject _bonusGettingView, _background;
    [SerializeField] private BonusCongratulationsView _bonusCongratulationsView;

    [SerializeField] private List<GetDailyBonusButton> _bonusButtons = new List<GetDailyBonusButton>();

    [SerializeField] private DailyBonusProgress _bonusProgressView;

    [Tooltip("Interval in seconds (86400 - 1 day)")]
    [SerializeField] private int _bonusInterval;

    #region Internal vars
    private int _bonusesCount => _bonusButtons.Count;
    private GameObject _currentPanel; //панель, которая отображается в текущий момент
    private bool _isShowing;
    #endregion
    public int BonusesCount => _bonusesCount;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);

        Init();
        Hide();
    }

   
    void Init()
    {
        int nextBonusNum = 0;
        if (!UserData.Instance.Read<int>(UserData.Instance.Keys.NextBonusNumber, out nextBonusNum))
        {
            UserData.Instance.Write<int>(UserData.Instance.Keys.NextBonusNumber, 0);
        }
        else if (UserData.Instance.Read<string>(UserData.Instance.Keys.LastBonusDate, out string lastStr))
        {
            DateTime lastBonusDate = DateTime.Parse(lastStr);
            DateTime nowTime = DateTime.Now;
            int diffFromLast = (int)(nowTime - lastBonusDate).TotalSeconds;

            if (diffFromLast > _bonusInterval * 2)
            {
                UserData.Instance.Write<int>(UserData.Instance.Keys.NextBonusNumber, 0);
            }
        }
        UserData.Instance.Read<int>(UserData.Instance.Keys.NextBonusNumber, out nextBonusNum);
        
        for (int i = 0; i < _bonusesCount; i++)
        {
            if (i < nextBonusNum)
            {
                _bonusButtons[i].SetStatus(DailyBonusButtonStatus.Complete);
            }
            if (i > nextBonusNum)
            {
                _bonusButtons[i].SetStatus(DailyBonusButtonStatus.Closed);
            }
            if(i == nextBonusNum)
            {
                bool available = IsBonusAvailable(out int num);
                _bonusProgressView.UpdateData(num, available);
                if (available)
                {
                    _bonusButtons[i].SetStatus(DailyBonusButtonStatus.Interactable);
                }
                else
                {
                    _bonusButtons[i].SetStatus(DailyBonusButtonStatus.Closed);
                }

            }
        }
    }

    bool IsBonusAvailable(out int nextBonusNumber)
    {
        int nextBonus = 0;
        UserData.Instance.Read<int>(UserData.Instance.Keys.NextBonusNumber, out nextBonus);
        nextBonusNumber = nextBonus;


        if (!UserData.Instance.Read<string>(UserData.Instance.Keys.LastBonusDate, out string lastStr))
        {
            return true;
        }
        else
        {
            DateTime lastBonusDate = DateTime.Parse(lastStr);
            DateTime nowTime = DateTime.Now;
            int diffFromLastDate = (int)(nowTime - lastBonusDate).TotalSeconds;

           // print($"lastDate: {lastBonusDate.TimeOfDay},     now: {nowTime.TimeOfDay}, diff: {diffFromLastDate}");
            
            if (diffFromLastDate < _bonusInterval) return false;
            if (diffFromLastDate > _bonusInterval * 2)
            {
                if (nextBonus == 0) return true;
                return false;
            }
            if (diffFromLastDate > _bonusInterval) return true;
        }

        




        return false;
    }

    public void GetBonus(DailyBonusViewData data)
    {
        if(IsBonusAvailable(out int nextBonusNum))
        {
            ShowCongratulations(data);
            UserData.Instance.AddTickets(data.TicketsCount);

            if (nextBonusNum + 1 > _bonusesCount - 1)
            {
                UserData.Instance.Write<int>(UserData.Instance.Keys.NextBonusNumber, 0);
            }
            else
            {
                UserData.Instance.Write<int>(UserData.Instance.Keys.NextBonusNumber, nextBonusNum + 1);
            }

            UserData.Instance.Write<string>(UserData.Instance.Keys.LastBonusDate, DateTime.Now.ToString());
        }
        else
        {
            Hide();
        }
        

        


    }

    #region WindowPopup
    void ShowPanel(GameObject panel)
    {
        if (_currentPanel != null) { _currentPanel.SetActive(false); }

        _currentPanel = panel;
        panel.SetActive(true);
    }
    public void Show()
    {
        if (_isShowing) return;
        _background.SetActive(true);
        _background.GetComponent<Image>().DOFade(.9f, .5f).SetEase(Ease.OutCirc);

        _isShowing = true;

    }
    public void Hide()
    {
        if (!_isShowing) return;

        _background.GetComponent<Image>().DOFade(0f, .5f).SetEase(Ease.OutCirc).OnComplete(() => { _background.SetActive(false); });
        HidePanel();
        _isShowing = false;
    }
    public void ShowCongratulations(DailyBonusViewData data)
    {
        _bonusCongratulationsView.SetData(data);
        ShowPanel(_bonusCongratulationsView.gameObject);
    }
    public void ShowGetting()
    {
        Init();
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
    #endregion




}
