using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
    private const string m_newCarId = "com.ethangreaves.monogalactic.newship";
    public const string m_newShipUnlockedKey = "NewShipUnlocked";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == m_newCarId)
        {
            PlayerPrefs.SetInt(m_newShipUnlockedKey, 1);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"Failed to purchase product {product.definition.id} because {reason}");
    }
}
