using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGetDailyBonusButton : GetDailyBonusButton
{
    [SerializeField] private Image _glowing;
    [SerializeField] private float _maxRadius;

    [Header("Punch")]
    [SerializeField] private Vector3 _punchVec;
    [SerializeField] private float _durationPunch, _elasticPunch;
    [SerializeField] private int _vibPunch;

    public void OnDisable()
    {
        base.OnDisable();
        _glowing.transform.localScale = Vector3.one;
        _glowing.transform.DOKill();
       
    }
   
    protected override void SetInteractable()
    {
        base.SetInteractable();
        _glowing.gameObject.SetActive(true);
        _glowing.transform.DOPunchScale(_punchVec, _durationPunch, _vibPunch, _elasticPunch).SetEase(Ease.InOutQuart).SetLoops(-1);
        _glowing.transform.DORotate(new Vector3(0, 0, 360), 10,RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
        
    }
    protected override void SetComplete()
    {
        base.SetComplete();
        _glowing.gameObject.SetActive(false);
    }
    protected override void SetClosed()
    {
        base.SetClosed();
        _glowing.gameObject.SetActive(false);
    }
}
