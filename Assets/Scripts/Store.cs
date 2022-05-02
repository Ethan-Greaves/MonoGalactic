using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
    private const string newCarId = "com.ethangreaves.monogalactic.newship";
    public const string newShipUnlockedKey = "NewShipUnlocked";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == newCarId)
        {
            PlayerPrefs.SetInt(newShipUnlockedKey, 1);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"Failed to purchase product {product.definition.id} because {reason}");
    }
}
