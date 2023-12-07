using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    

    public virtual void Show(Action OnComplete)
    {

    }

    public void Show()
    {
        Show(() => { });
    }
    public virtual void Hide(Action OnComplete)
    {

    }

    public void Hide()
    {
        Hide(() => { });
    }
    
}
