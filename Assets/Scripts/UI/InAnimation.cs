using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAnimation : MonoBehaviour
{

    [SerializeField] private float _duration;
    [SerializeField] private Ease _mode;
    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        transform.DOScale(Vector3.zero, 0);
        transform.DOScale(Vector3.one, _duration).SetEase(_mode);
    }
    void OnDisable()
    {
        transform.DOScale(Vector3.zero, 0);

    }

   
}
