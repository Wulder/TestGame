using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMapView : View
{
    [SerializeField] private GameObject _background, _content;
    [SerializeField] private LevelsDrawer _levelsDrawer;

    private void Awake()
    {
        _background.SetActive(false);
        _content.SetActive(false);
    }
    public override void Show(Action OnComplete)
    {
        _background.SetActive(true);

        _background.transform.DOScaleY(0, 0);

        OnComplete += ShowContent;

        _background.transform.DOScaleY(1, .5f).SetEase(Ease.InOutQuart).OnComplete(OnComplete.Invoke);
    }

    public override void Hide(Action OnComplete)
    {
        HideContent();
        _background.transform.DOScaleY(0, .5f).SetEase(Ease.InOutQuart).OnComplete(OnComplete.Invoke);

    }

    void ShowContent()
    {
        _levelsDrawer.DrawLine();
        _content.SetActive(true);
    }
    void HideContent()
    {
        _content.SetActive(false);
    }
}
