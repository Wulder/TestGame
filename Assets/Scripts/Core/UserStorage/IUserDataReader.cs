using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserDataReader
{
    public bool Read<T>(string key, out T value);
}
