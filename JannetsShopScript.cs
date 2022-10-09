using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JannetsShopScript : MonoBehaviour
{
    [Header("Shop Item Sprites")]
    [SerializeField] GameObject ChestPlate;
    [SerializeField] GameObject Starter_Rod;
    [SerializeField] GameObject FishingRod_1;
    [SerializeField] GameObject FishingRod_2;
    [SerializeField] GameObject Potion_5;// health potion
    [SerializeField] GameObject Potion_8; 
    [SerializeField] GameObject Sword_4;
    [SerializeField] GameObject Sword_7;

    //[Header("setting for each slot")]
    //public GameObject slotItemPrefab;

    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        CloseShop();
    }
    /*
    private void Start()
    {
        CreateItemButton(ChestPlate, "ChestPlate", ItemsScript.ArmorList.Find(v => v.name == "ChestPlate").cost, 0);
        CreateItemButton(Starter_Rod, "Starter_Rod", ItemsScript.FishingRodsList.Find(v => v.name == "Starter_Rod").cost, 1);
        CreateItemButton(FishingRod_1, "FishingRod_1", ItemsScript.FishingRodsList.Find(v => v.name == "FishingRod_1").cost, 2);
        CreateItemButton(FishingRod_2, "FishingRod_2", ItemsScript.FishingRodsList.Find(v => v.name == "FishingRod_2").cost, 3);
        CreateItemButton(Potion_5, "Potion_5", ItemsScript.ConsumableList.Find(v => v.name == "Potion_5").cost, 4);
        CreateItemButton(Potion_8, "Potion_8", ItemsScript.ConsumableList.Find(v => v.name == "Potion_8").cost, 5);
        CreateItemButton(Sword_4, "Sword_4", ItemsScript.WeaponsList.Find(v => v.name == "Sword_4").cost, 6);
        CreateItemButton(Sword_7, "Sword_7", ItemsScript.WeaponsList.Find(v => v.name == "Sword_7").cost, 7);
    }
    */
    public void OpenShop(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
        //shopItemTemplate.gameObject.SetActive(true);
        //container = transform.Find("Container");
        //shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);

        CreateItemButton(ChestPlate, "ChestPlate", ItemsScript.ArmorList.Find(v => v.name == "ChestPlate").cost, 0);
        CreateItemButton(Starter_Rod, "Starter_Rod", ItemsScript.FishingRodsList.Find(v => v.name == "Starter_Rod").cost, 1);
        CreateItemButton(FishingRod_1, "FishingRod_1", ItemsScript.FishingRodsList.Find(v => v.name == "FishingRod_1").cost, 2);
        CreateItemButton(FishingRod_2, "FishingRod_2", ItemsScript.FishingRodsList.Find(v => v.name == "FishingRod_2").cost, 3);
        CreateItemButton(Potion_5, "Potion_5", ItemsScript.ConsumableList.Find(v => v.name == "Potion_5").cost, 4);
        CreateItemButton(Potion_8, "Potion_8", ItemsScript.ConsumableList.Find(v => v.name == "Potion_8").cost, 5);
        CreateItemButton(Sword_4, "Sword_4", ItemsScript.MeleeWeaponsList.Find(v => v.name == "Sword_4").cost, 6);
        CreateItemButton(Sword_7, "Sword_7", ItemsScript.MeleeWeaponsList.Find(v => v.name == "Sword_7").cost, 7);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    private void CreateItemButton(GameObject itemPreFab, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container); // makes parent = container
        RectTransform shopItemRectTransform = shopItemTemplate.GetComponent<RectTransform>();
        float shopItemHeight = 30;
        shopItemTransform.GetComponent<JannetsShopSlotScript>().slotItemPrefab = itemPreFab;
        shopItemTransform.GetComponent<JannetsShopSlotScript>().slotItemCost = itemCost;
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
