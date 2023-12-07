using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyBonusButtonsAnimation : MonoBehaviour
{
   private List<Transform> _buttons = new List<Transform>();
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        _buttons.Clear();
        for(int i = 0; i < transform.childCount; i++)
        {
            _buttons.Add(transform.GetChild(i));
        }

        float delay = 0;
        foreach(Transform b in _buttons)
        {
            b.DOScale(Vector3.zero, 0); 
            b.DOScale(Vector3.one, .5f).SetDelay(delay+=_delay);
        }
        
    }

    private void OnDisable()
    {
        foreach (Transform b in _buttons)
        {
            b.DOScale(Vector3.zero, 0);
        }
    }

}
