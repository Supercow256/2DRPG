using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindysShopSlotScript : MonoBehaviour
{
    public GameObject slotItemPrefab;
    public int slotItemCost;
    public string itemName;
    GameObject mindysShopObject;

    void Start()
    {
        mindysShopObject = this.transform.parent.transform.parent.gameObject;
        Debug.Log("" + mindysShopObject.name);
    }

    public void OnButtonClick()
    {
        mindysShopObject.GetComponent<MindysShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, itemName, "PetsList");
        //mindysShopObject.GetComponent<MindysShopScript>().TryBuyItem(slotItemPrefab, slotItemCost, "WeaponsList");
            
    }
}
