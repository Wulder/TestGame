using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPReader : IUserDataReader
{
    public bool Read<T>(string key, out T value)
    {

        if (!PlayerPrefs.HasKey(key))
        {
            Debug.Log($"Key {key} is not exists!");
            value = default(T); return false;
        }

        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Int32:
                {
                    value = (T)(object)PlayerPrefs.GetInt(key);
                    return true;
                }
            case TypeCode.Single:
                {
                    value = (T)(object)PlayerPrefs.GetFloat(key);
                    return true;
                }
            case TypeCode.String:
                {
                    value = (T)(object)PlayerPrefs.GetString(key);
                    return true;
                }
            default:
                {
                    Debug.Log("Trying read unexpected type!");
                    value = default(T);
                    return false;
                }
        }



    }
}
