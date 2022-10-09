using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    public void BoughtItem(GameObject Prefab, string itemName, string listType);
    public bool TrySpendingGoldAmount(int goldAmount);
}
