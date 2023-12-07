using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//реализация синглтона на коленке
public abstract class Singletone<T>
{
    private static T instance;
    public static T Instance => instance;

    public Singletone()
    {
        if (instance == null)
            instance = GetSelf();
    }

    protected abstract T GetSelf();
  
}
