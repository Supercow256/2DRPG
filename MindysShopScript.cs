using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindysShopScript : MonoBehaviour
{

    [Header("Shop Item Sprites")]
    [SerializeField] GameObject Red_Slime;
    [SerializeField] GameObject Green_Slime;
    [SerializeField] GameObject Blue_Slime;
    [SerializeField] GameObject Orange_Slime;
    [SerializeField] GameObject Shroomy;
    //[SerializeField] GameObject Red_Slime;

    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    
    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        CloseShop();
    }

    public void OpenShop(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
        //shopItemTemplate.gameObject.SetActive(true);
        //container = transform.Find("Container");
        //shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);

        //Debug.Log(Red_Slime.name);
        //Debug.Log("" + ItemsScript.PetsList.Find(v => v.name == "Red_Slime").cost);

        CreateItemButton(Red_Slime, "Red_Slime", ItemsScript.PetsList.Find(v => v.name == "Red_Slime").cost, 0);
        CreateItemButton(Green_Slime, "Green_Slime", ItemsScript.PetsList.Find(v => v.name == "Green_Slime").cost, 1);
        CreateItemButton(Blue_Slime, "Blue_Slime", ItemsScript.PetsList.Find(v => v.name == "Blue_Slime").cost, 2);
        CreateItemButton(Orange_Slime, "Orange_Slime", ItemsScript.PetsList.Find(v => v.name == "Orange_Slime").cost, 3);
        CreateItemButton(Shroomy, "Shroomy", ItemsScript.PetsList.Find(v => v.name == "Shroomy").cost, 3);

    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    private void CreateItemButton(GameObject itemPreFab, string itemName, int itemCost, int positionIndex)
    {
        Debug.Log(itemPreFab);
        Debug.Log(itemName);
        Debug.Log(itemCost);
        Debug.Log(positionIndex);

        Transform shopItemTransform = Instantiate(shopItemTemplate, container); // makes parent = container
        RectTransform shopItemRectTransform = shopItemTemplate.GetComponent<RectTransform>();
        float shopItemHeight = 35;
        shopItemTransform.GetComponent<MindysShopSlotScript>().slotItemPrefab = itemPreFab;
        shopItemTransform.GetComponent<MindysShopSlotScript>().slotItemCost = itemCost;
        shopItemTransform.GetComponent<MindysShopSlotScript>().itemName = itemName;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * (positionIndex + 1));
        shopItemTransform.Find("NameText").GetComponent<Text>().text = itemName;
        shopItemTransform.Find("PriceText").GetComponent<Text>().text = itemCost.ToString();

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemPreFab.GetComponent<SpriteRenderer>().sprite;
        shopItemTransform.gameObject.SetActive(true);
    }

    public void TryBuyItem(GameObject Prefab, int cost, string itemName, string listType)
    {
        if (shopCustomer.TrySpendingGoldAmount(cost))
        {
            shopCustomer.BoughtItem(Prefab, itemName, listType);
        }
    }
}
