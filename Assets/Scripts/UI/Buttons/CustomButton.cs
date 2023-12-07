using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomButton : Button
{

    protected abstract bool IsPressed();

    protected virtual void OnIsPressed()
    {

    }

    protected virtual void OnIsUnpressed()
    {

    }

    protected virtual void OnClick() { }

    protected override void Awake()
    {
        onClick.AddListener(OnClick);
    }
    protected void OnEnable()
    {
        if(IsPressed())
        {
            OnIsPressed();
        }
        else
        {
            OnIsUnpressed();
        }
    }
    
}
