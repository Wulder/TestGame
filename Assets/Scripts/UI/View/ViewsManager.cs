using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsManager : MonoBehaviour
{
    
    [SerializeField] private List<ViewData> _views = new List<ViewData>();
    [SerializeField] private View _initView;

    private View _currentView;

    void Start()
    {
        _currentView = _initView;
    }

    void ShowView(View view)
    {
        if (_currentView)
        {
            _currentView.Hide(view.Show);
            _currentView = null;
            return;
        }

        view.Show();
        _currentView = view;
    }

    //Сначала показывает нужный экран и по окончанию закрывает текущий
    void ReverseShowView(View view)
    {
        if(_currentView)
        {
            view.Show(_currentView.Hide);
            _currentView = view;
            return;
        }

        view.Show();
        _currentView = view;

    }

    public void Show(ViewType vt, bool isReverse = false)
    {
        ViewData vd = _views.Find(v => v.Type == vt);

        if (!isReverse)
            ShowView(vd.View);
        else
            ReverseShowView(vd.View);
    }


}

[Serializable]
public enum ViewType
{
    Main,
    Store,
    Levels
}

[Serializable]
public struct ViewData
{
    public ViewType Type;
    public View View;
}
