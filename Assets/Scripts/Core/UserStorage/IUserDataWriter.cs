using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserDataWriter 
{
    public bool Write<T>(string key, T value);
}
