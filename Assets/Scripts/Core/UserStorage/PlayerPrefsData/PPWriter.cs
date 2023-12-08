using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPWriter : IUserDataWriter
{
    public void DeleteKey(string key)
    {
       PlayerPrefs.DeleteKey(key);
    }

    public bool Write<T>(string key, T value)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Int32:
                {
                    int val = (int)(object)value;
                   PlayerPrefs.SetInt(key,val);
                    return true;
                }
            case TypeCode.Single:
                {
                    float val = (float)(object)value;
                    PlayerPrefs.SetFloat(key, val);
                    return true;
                }
            case TypeCode.String:
                {
                    string val = (string)(object)value;
                    PlayerPrefs.SetString(key, val);
                    return true;
                }
            default:
                {
                    Debug.Log("Trying write unexpected type!");
                    return false;
                }
        }
    }
}
