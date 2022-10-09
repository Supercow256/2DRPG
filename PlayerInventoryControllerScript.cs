using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerInventoryControllerScript : MonoBehaviour
{
    public static bool inventoryOpen;
    public static GameObject Inventory;
    public static GameObject[,] InventorySlots = new GameObject[4,7];
    public static string[, ] InventorySlotsItemName = new string[4, 7];
    public static bool[,] InventorySlotUsed = new bool[4, 7];
    public static string NameOfCollider;
    public static int amountOfItems;
    public static int freeRow;
    public static int freeCol;
    public static bool showHand;
    public static string nameOfHeldItem;
    public static int currentHotBarSlot;

    public bool freeze;
    private int lastHotBarSlot;

    // vars for changing item slot

    // for old slot
    public bool firstTimeClicked;
    public GameObject tempSlot;
    public int tempSlotRow;
    public int tempSlotCol;
    public string tempSlotItemName;
    public Sprite tempSprite;
    // for new slot
    public GameObject tempSlotImageObject;
    // vars for changing item slot

    // Start is called before the first frame update
    void Start()
    {
        firstTimeClicked = true;
        //Inventory = GameObject.Find("Inventory UI");
        Inventory = transform.GetChild(0).gameObject;
        inventoryOpen = false;
        HideInventory();
        //Inventory.SetActive(inventoryOpen);
        int count = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                
                InventorySlotUsed[i, j] = false;
                InventorySlotsItemName[i, j] = "";
                InventorySlots[i, j] = transform.Find("Inventory UI").transform.Find("Inventory").transform.Find("ItemsParent").transform.Find("InventorySlot (" + (count) + ")").gameObject;
                count++;
            }
        }
        for (int i = 0; i < 28; i++)
        {
            Inventory.transform.GetChild(0).transform.GetChild(i).GetComponent<InventorySlotScript>().SlotNum = i+1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if ((StartUpScreenButtonsScript.singlePlayerBool || GetComponent<CharacterController>().view.IsMine) && freeze == false)
        {
            lastHotBarSlot = currentHotBarSlot;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentHotBarSlot > 1)
                {
                    currentHotBarSlot--;
                }
                else
                {
                    currentHotBarSlot = 7;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentHotBarSlot < 7)
                {
                    currentHotBarSlot++;
                }
                else
                {
                    currentHotBarSlot = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            {
                currentHotBarSlot = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentHotBarSlot = 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentHotBarSlot = 2;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentHotBarSlot = 3;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentHotBarSlot = 4;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            {
                currentHotBarSlot = 5;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            {
                currentHotBarSlot = 6;
            }
            if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            {
                currentHotBarSlot = 7;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (inventoryOpen == false)
                {
                    ShowInventory();
                    //AddItemToInventory();
                    inventoryOpen = !inventoryOpen;
                }
                else if (inventoryOpen == true)
                {
                    HideInventory();
                    inventoryOpen = !inventoryOpen;
                }
            }

            if (lastHotBarSlot != 0 /*currentHotBarSlot != 0*/)
            {
                //Debug.Log("" + lastHotBarSlot);
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + lastHotBarSlot + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = false;
                GetComponent<CharacterController>().Player.transform.Find("Character Hand").GetComponent<SpriteRenderer>().sprite = transform.GetChild(1).transform.Find("HotBar").transform.Find("HotBarSlot (" + currentHotBarSlot + ")").transform.Find("ItemImg").GetComponent<Image>().sprite;
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + currentHotBarSlot + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = true;
                nameOfHeldItem = InventorySlotsItemName[0, currentHotBarSlot - 1];
                //Debug.Log(nameOfHeldItem);
            }
            else
            {
                transform.Find("Character Hand").GetComponent<SpriteRenderer>().enabled = false;
                //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + lastHotBarSlot + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = false;
                for (int i = 1; i < 8; i++)
                {
                    SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + i + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = false;

                }
            }
        }
    }
    /*
    public void UpdateHand()
    {
        GameObject.Find("Canvas 02").transform.Find("HotBar").transform.Find("HotBarSlot (" + lastHotBarSlot + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = false;
        CharacterController.Player.transform.Find("Character Hand").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Canvas 02").transform.Find("HotBar").transform.Find("HotBarSlot (" + currentHotBarSlot + ")").transform.Find("ItemImg").GetComponent<Image>().sprite;
        GameObject.Find("Canvas 02").transform.Find("HotBar").transform.Find("HotBarSlot (" + currentHotBarSlot + ")").transform.Find("ItemButton").transform.Find("Outline").GetComponent<Image>().enabled = true;
    }
    */

    public static void GetNameOfCollider(string name)
    {
        NameOfCollider = name;
    }

    public static void GetFreeInventorySlot()
    {
        bool search = true;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (!InventorySlotUsed[i, j])
                {
                    //Debug.Log(i + "," + j);
                    freeRow = i;
                    freeCol = j;
                    return;
                    //search = false;
                }
            }
        }
        return;

    }


    public static void AddItemToInventory(GameObject gameObj)
    {
        if (amountOfItems == 28)
        {
            Debug.Log("Inventory is full");
        }
        else
        {
            amountOfItems++;
            //Debug.Log("Item you collided with is " + NameOfCollider);
            GetFreeInventorySlot();
            //Debug.Log("Current free row and col are: " + freeRow + ", " +  freeCol);
            if (freeRow < 5 && freeCol < 7)
            {
                InventorySlots[freeRow, freeCol].transform.Find("ItemImg").GetComponent<Image>().enabled = true;
                InventorySlots[freeRow, freeCol].transform.Find("ItemImg").GetComponent<Image>().sprite = GameObject.Find(NameOfCollider).GetComponent<SpriteRenderer>().sprite;
                InventorySlots[freeRow, freeCol].GetComponent<InventorySlotScript>().itemGameObject = gameObj;

                if (NameOfCollider.Substring(NameOfCollider.Length - 7, 7).Equals("(Clone)"))
                {
                    InventorySlotsItemName[freeRow, freeCol] = NameOfCollider.Substring(0, NameOfCollider.Length - 7);
                }
                else
                {
                    InventorySlotsItemName[freeRow, freeCol] = NameOfCollider;
                }
                InventorySlotUsed[freeRow, freeCol] = true;
                Destroy(GameObject.Find(NameOfCollider));
            }


            if (freeRow == 0)
            {
                //Debug.Log("UpdateHotBar");
                //Debug.Log("Name of Player Object is:" + SpawnPlayers.MYPLAYER.name);
                //Debug.Log("" + SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (freeCol + 1) + ")").name);
                //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (freeCol + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = true;
                //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (freeCol + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = InventorySlots[0, freeCol].transform.Find("ItemImg").GetComponent<Image>().sprite;
                UpdateHotbar();
            }
        }

    }

    void ClearInventroy()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //_PlayerInventory[i, j] = null;
            }
        }
    }

    void HideInventory()
    {
        GameObject.Find("Inventory UI").GetComponent<Canvas>().enabled = false;
    }

    void ShowInventory()
    {
        GameObject.Find("Inventory UI").GetComponent<Canvas>().enabled = true; 
    }

    public static void UpdateHotbar()
    {
        for (int i = 1; i < 8; i++)
        {
            //GameObject.Find("HotBarSlot (" + (i) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = true;
            //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (i) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = InventorySlots[0, i-1].transform.Find("ItemImg").GetComponent<Image>().sprite;
            if (InventorySlotUsed[0,i-1])
            {
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (i) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = true;
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (i) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = InventorySlots[0, i - 1].transform.Find("ItemImg").GetComponent<Image>().sprite;
            }
        }
    }

}
