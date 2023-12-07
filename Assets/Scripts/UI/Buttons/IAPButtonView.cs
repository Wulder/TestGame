using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(CodelessIAPButton))]
public class IAPButtonView : Button
{
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private CodelessIAPButton _iap;
    void Start()
    {
        if(_priceText)
        {

            foreach(var p in ProductCatalog.LoadDefaultCatalog().allProducts)
            {
                if(_iap.productId == p.id)
                {
                    _priceText.text = $"{p.googlePrice.value}$";
                    _nameText.text = $"[{_iap.productId}]";
                }
            }
                
        }
    }

    
}
