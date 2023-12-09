using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPStore : MonoBehaviour
{
    [SerializeField] private OnPurchaseView _view;
    

    public void OnPurchaseProduct(Product product)
    {
        switch(product.definition.id)
        {
            case "EpicChest":
                {
                    OnBuyEpicChest(product);
                    break;
                }
            case "LuckyChest":
                {
                    OnBuyLuckyChest(product);
                    break;
                }
        }
    }

    void OnBuyEpicChest(Product p)
    {
        Debug.Log("You are buy an Epic chest!");
        AddCurrency(p);
        
    }

    void OnBuyLuckyChest(Product p)
    {
        Debug.Log("You are buy an Lucky chest!");
        AddCurrency(p);
    }

    void AddCurrency(Product p)
    {
        int count = (int)p.definition.payouts.First().quantity;
        UserData.Instance.AddTickets(count);
        _view.ShowText($"You are bought {count} tickets!");
    }
}
