using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InternalStoreLogic : MonoBehaviour
{
    private static InternalStoreLogic instance;
    public static InternalStoreLogic Instance => instance;  
    private InternalStore _store;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        _store = InternalStore.Instance;
    }
    public void BuyRandomTickets()
    {
        InternalStore.Instance.Buy(4, BuyRandomTicketsCallback);
    }

    void BuyRandomTicketsCallback()
    {
        int tCount = UnityEngine.Random.Range(0, 10);

        int own = 0;
        if(UserData.Instance.Read<int>(UserData.Instance.Keys.Tickets, out own))
        {
            UserData.Instance.Write<int>(UserData.Instance.Keys.Tickets, own + tCount);
        }
        
    }

    public void Buy<T>(int price, string key, T value)
    {
        _store.Buy(price, () => { BuyCallback(key,value); });


    }

    void BuyCallback<T>(string key, T value)
    {
        UserData.Instance.Write(key,value);
    }


    //функция для очистки значений в реестре, добавлена в рамках теста, в билде быть не должно
#if UNITY_EDITOR
    [ContextMenu("Reset PP")]
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
#endif

}
