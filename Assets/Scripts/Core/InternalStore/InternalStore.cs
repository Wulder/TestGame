using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Клас реализующий возможность совершать внутриигровые покупки
public class InternalStore : Singletone<InternalStore>
{
    protected override InternalStore GetSelf()
    {
        return this;
    }

    public bool Buy(int price, Action successCallback)
    {
       
        int ownTickets = 0;
        if(UserData.Instance.Read<int>(UserData.Instance.Keys.Tickets, out ownTickets))
        {
            if(ownTickets >= price)
            {
                UserData.Instance.Write<int>(UserData.Instance.Keys.Tickets, ownTickets - price);
                successCallback.Invoke();
                return true;
            }
            else
            {
                Debug.Log($"Not enough tickets! requires:({price}), have: {ownTickets}");
            }    
        }

        Debug.Log("Trying get tickets is false");
        return false;
    }
}
