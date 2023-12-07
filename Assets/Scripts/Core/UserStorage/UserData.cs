using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Класс для чтения/записи данных пользователя (валюта, расходники, отключение рекламы и т.д.) в рамках игровой сессии 
public class UserData : Singletone<UserData>
{

    public event Action<string> OnDataUpdated;

    //реализации чтения/записи данных пользователя, в данном проекте я буду использовать обычные PlayerPrefs, 
    //но данные интерфейсы позволят нам создать реализацию для записи и чтения в базы данных различных сторов или серверов
    private IUserDataReader _reader;
    private IUserDataWriter _writer;

    //константы ключей, хранящихся в базе данных (в нашем случаее реестр)
    private DataKeys _keys;
    public DataKeys Keys => _keys;
    public UserData(IUserDataReader reader, IUserDataWriter writer, DataKeys dKeys) : base()
    {
        _reader = reader;
        _writer = writer;
        _keys = dKeys;
    }

    public bool Read<T>(string key, out T val)
    {
        if (_reader.Read<T>(key, out T value))
        {
            val = value;
            return true;
        }
            

        Debug.Log("Can't read value");
        val = default(T);
        return false;
    }
    public void Write<T>(string key, T data)
    {
        if (!_writer.Write<T>(key, data))
            Debug.Log("Can't write data");
        else
            OnDataUpdated?.Invoke(key);
    }

    public void AddTickets(int count)
    {
        int own = 0;

        Read<int>(Keys.Tickets, out own);

        Write<int>(Keys.Tickets, own+count);
    }

    protected override UserData GetSelf()
    {
        return this;
    }
}


