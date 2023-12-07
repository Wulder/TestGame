using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteReadExample : MonoBehaviour
{
    private DataKeys _keys;
    // Start is called before the first frame update
    void Start()
    {
        _keys = UserData.Instance.Keys;
    }

   

    [ContextMenu("remove tickets")]
    void RemoveTickets()
    {
        int result = 0;
        if (UserData.Instance.Read<int>(_keys.Tickets, out result))
        {
            result -= 5;
        }
        UserData.Instance.Write<int>(_keys.Tickets, result);
    }

    [ContextMenu("add tickets")]
    void AddTickets()
    {
        int add = 0;
        if(UserData.Instance.Read<int>(_keys.Tickets, out add))
        {
            add += 5;
        }
        UserData.Instance.Write<int>(_keys.Tickets, add);
    }
}
