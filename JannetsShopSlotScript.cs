using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JannetsShopSlotScript : MonoBehaviour
{
    public GameObject slotItemPrefab;
    public int slotItemCost;
    GameObject jannetsShopObject;
    string itemName;
    void Start()
    {
        jannetsShopObject = this.transform.parent.transform.parent.gameObject;
        Debug.Log("" + jannetsShopObject.name);
    }

    public void OnButtonClick()
    {
        if (ItemsScript.MeleeWeaponsList.Contains(ItemsScript.MeleeWeaponsList.Find(v => v.name == slotItemPrefab.name)))
        {
            jannetsShopObject.GetComponent<JannetsShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "MeleeWeaponsList");
        }
        else if (ItemsScript.ConsumableList.Contains(ItemsScript.ConsumableList.Find(v => v.name == slotItemPrefab.name)))
        {
            jannetsShopObject.GetComponent<JannetsShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "ConsumableList");
        }
        else if (ItemsScript.FishingRodsList.Contains(ItemsScript.FishingRodsList.Find(v => v.name == slotItemPrefab.name)))
        {
            jannetsShopObject.GetComponent<JannetsShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "FishingRodsList");
        }
        else if (ItemsScript.FishList.Contains(ItemsScript.FishList.Find(v => v.name == slotItemPrefab.name)))
        {
            jannetsShopObject.GetComponent<JannetsShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "FishList");
        }
        else if (ItemsScript.ArmorList.Contains(ItemsScript.ArmorList.Find(v => v.name == slotItemPrefab.name)))
        {
            jannetsShopObject.GetComponent<JannetsShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "ArmorList");
        }
    }
}
