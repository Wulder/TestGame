using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewInvoker : MonoBehaviour
{
    [SerializeField] private ViewType _type;
    [SerializeField] private bool isReverse;
    [SerializeField] private ViewsManager _viewsManager;
    
    public void Invoke()
    {
       
        _viewsManager.Show(_type, isReverse);
    }
}
