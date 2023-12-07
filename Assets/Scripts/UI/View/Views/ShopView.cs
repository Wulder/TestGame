using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : View
{
    [SerializeField] private GameObject _background, _content;
    [SerializeField] private float _inSpeed, _outSpeed;

    private void Start()
    {
        _background.SetActive(false);
        _content.SetActive(false);
    }
    public override void Show(Action OnComplete)
    {
        
        var image = _background.GetComponent<Image>();

        _background.SetActive(true);

        OnComplete += ShowContent;

        image.DOFade(0, 0f);
        image.DOFade(1, _inSpeed).SetEase(Ease.OutQuad).OnComplete(OnComplete.Invoke);
        
        void ShowContent()
        {
            _content.SetActive(true);
            _content.transform.DOScale(Vector3.zero, 0);
            _content.transform.DOScale(Vector3.one, _inSpeed).SetEase(Ease.OutQuad);
        }

    }

    public override void Hide(Action OnComplete)
    {
        var image = _background.GetComponent<Image>();

        HideContent();

       

        void HideContent()
        {
            _content.transform.DOScale(Vector3.zero, _outSpeed).SetEase(Ease.OutQuad).OnComplete(() => {
                _content.SetActive(false);
                OnComplete += () => { _background.SetActive(false); };

                image.DOFade(0, _outSpeed).SetEase(Ease.OutQuad).OnComplete(OnComplete.Invoke);
            });
            
        }

    }
}
