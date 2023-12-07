using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnPurchaseView : View
{
    [SerializeField] private GameObject _content;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Ease _easeMode;
    public override void Show(Action OnComplete)
    {
        _content.SetActive(true);
        _content.transform.DOScale(Vector3.zero, 0);
        _content.transform.DOScale(Vector3.one, .5f).SetEase(_easeMode);
    }

    public override void Hide(Action OnComplete)
    {
        _content.transform.DOScale(Vector3.zero, .5f).SetEase(_easeMode).OnComplete(() =>
        {
            _content.SetActive(false);
        });
    }

    public void ShowText(string text)
    {
        _text.text = text;
        Show(() => { });
    }
}
