using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ticketsCountText;
    private DataKeys _keys;
    void Start()
    {
        _keys = UserData.Instance.Keys;

        UserData.Instance.OnDataUpdated += UpdateUI;

        Init();
    }

   void Init()
    {
        UpdateTickets();
    }

    private void UpdateUI(string key)
    {
        if (key == _keys.Tickets) UpdateTickets();
    }

    [ContextMenu("Update Tickets")]
    private void UpdateTickets()
    {
        if(UserData.Instance.Read<int>(UserData.Instance.Keys.Tickets, out int value))
        {
            _ticketsCountText.text = value.ToString();
        }
    }

    public void GoToHome()
    {

    }
}
