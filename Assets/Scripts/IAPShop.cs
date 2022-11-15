using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{

    private string gold500 = "com.5stacks.bulletcity.gold500.[0.99]";
    private string gold1000 = "com.5stacks.bulletcity.gold1000.[1.99]";
    private string gold2500 = "com.5stacks.bulletcity.gold2500.[4.99]";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == gold500)
        {
            //reward player gold
        }
         
        if (product.definition.id == gold1000)
        {
            //reward player gold

        }

        if (product.definition.id == gold2500)
        {
            //reward player gold

        }
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
}
