using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : View
{
    [SerializeField] private GameObject _content;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Hide(Action OnComplete)
    {
        _content.SetActive(false);
        OnComplete.Invoke();
    }

    public override void Show(Action OnComplete)
    {
        _content.SetActive(true);
        OnComplete.Invoke();
    }
}
