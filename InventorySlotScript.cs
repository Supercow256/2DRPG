using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    public Image icon;
    public GameObject inventorySlotImage;
    public int SlotNum;
    public GameObject itemGameObject;

    private int curRow;
    private int curCol;
    //Item item;

    // Start is called before the first frame update
    void Start()
    {
        icon.sprite = inventorySlotImage.GetComponent<SpriteRenderer>().sprite;
        curRow = (int)((SlotNum-1) / 7);
        curCol = (SlotNum < 7) ? SlotNum-1 : (int)((SlotNum-1) % 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventoryItemClicked()
    {

        Debug.Log("Slot clicked" + curRow + "," + curCol);

        // IF CHEST OPEN TRANSFER TO CHESt
        if (ChestScript.chestIsOpen == true)
        {
            ChestScript.getFreeSlot();
            //Debug.Log("transfer item");
            ChestScript.chestInventorySlot[ChestScript.freeSlot].transform.Find("ItemImg").GetComponent<Image>().enabled = true;
            ChestScript.chestInventorySlotItemName[ChestScript.freeSlot] = PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol];
            PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol] = "";
            ChestScript.chestInventorySlot[ChestScript.freeSlot].transform.Find("ItemImg").GetComponent<Image>().sprite = transform.Find("ItemImg").GetComponent<Image>().sprite;
            transform.Find("ItemImg").GetComponent<Image>().enabled = false;
            RemoveItem();
        }
        //add any other ui "open"s here
        else if (false)
        {

        }
        else
        {
            //Debug.Log("SLot clicked and chest is closed");
            // Script for changing item in inventory to another slot
            if (SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().firstTimeClicked && PlayerInventoryControllerScript.InventorySlotUsed[curRow, curCol])
            {
                Debug.Log("First time clicked");
                // save slots info
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlot = PlayerInventoryControllerScript.InventorySlots[curRow, curCol];
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSprite = transform.Find("ItemImg").GetComponent<Image>().sprite;
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotItemName = PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol];
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotRow = curRow;
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotCol = curCol;
                //Image tempSlotImage = PlayerInventoryControllerScript.InventorySlots[curRow, curCol].GetComponent<;
                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().firstTimeClicked = false;

                // show outline of inventory slot here

            }
            else if (SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().firstTimeClicked == false)
            {
                //SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotImageObject = transform.parent.Find("ItemImg").gameObject;
                Debug.Log("second time clicked");
                if (PlayerInventoryControllerScript.InventorySlotUsed[curRow,curCol] == false)
                {
                    // remove last slot
                    SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlot.GetComponent<InventorySlotScript>().RemoveItem();
                }
                else
                {
                    PlayerInventoryControllerScript.InventorySlots[SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotRow, SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotCol].transform.Find("ItemImg").GetComponent<Image>().sprite = transform.Find("ItemImg").GetComponent<Image>().sprite;
                    PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol] = SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotItemName;
                }

                // move old to new slot
                PlayerInventoryControllerScript.InventorySlots[curRow, curCol].transform.Find("ItemImg").GetComponent<Image>().enabled = true;
                PlayerInventoryControllerScript.InventorySlots[curRow, curCol].transform.Find("ItemImg").GetComponent<Image>().sprite = SpawnPlayers.MYPLAYER.GetComponent< PlayerInventoryControllerScript>().tempSprite;
                PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol] = SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().tempSlotItemName;
                PlayerInventoryControllerScript.InventorySlotUsed[curRow, curCol] = true;


                SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().firstTimeClicked = true;
            }
            PlayerInventoryControllerScript.UpdateHotbar();
        }


    }

    public void TransferItemToInventory()
    {
        PlayerInventoryControllerScript.GetFreeInventorySlot();
        PlayerInventoryControllerScript.InventorySlots[PlayerInventoryControllerScript.freeRow, PlayerInventoryControllerScript.freeCol].transform.Find("ItemImg").GetComponent<Image>().enabled = true;
        PlayerInventoryControllerScript.InventorySlots[PlayerInventoryControllerScript.freeRow, PlayerInventoryControllerScript.freeCol].transform.Find("ItemImg").GetComponent<Image>().sprite = transform.Find("ItemImg").GetComponent<Image>().sprite;
        PlayerInventoryControllerScript.InventorySlotUsed[PlayerInventoryControllerScript.freeRow, PlayerInventoryControllerScript.freeCol] = true;
        Debug.Log("" + ChestScript.chestInventorySlotItemName[SlotNum]);
        PlayerInventoryControllerScript.InventorySlotsItemName[PlayerInventoryControllerScript.freeRow, PlayerInventoryControllerScript.freeCol] = ChestScript.chestInventorySlotItemName[SlotNum];
        if (PlayerInventoryControllerScript.freeRow == 0)
        {
            //Debug.Log("UpdateHotBar");
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (PlayerInventoryControllerScript.freeCol + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = true;
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (PlayerInventoryControllerScript.freeCol + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = transform.Find("ItemImg").GetComponent<Image>().sprite;
        }
        PlayerInventoryControllerScript.GetFreeInventorySlot();
        ChestScript.chestInventorySlot[SlotNum].transform.Find("ItemImg").GetComponent<Image>().enabled = false;
    }

    public void RemoveItem()
    {
        if (PlayerInventoryControllerScript.InventorySlotUsed[curRow, curCol])
        {
            PlayerInventoryControllerScript.amountOfItems--;
            //Debug.Log("Slot Num: " + SlotNum + "curRow: " + curRow+ "curCol: " + curCol);
            transform.Find("ItemImg").GetComponent<Image>().enabled = false;
            PlayerInventoryControllerScript.InventorySlotUsed[curRow, curCol] = false;
            PlayerInventoryControllerScript.InventorySlotsItemName[curRow, curCol] = "";

            if (SlotNum < 8)
            {
                //PlayerInventoryControllerScript.UpdateHotbar();
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (SlotNum) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = false;
                SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (SlotNum) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = null;

            }
        }

    }

    public static void RemoveHotBarItem()
    {
        /*
         * ---------------------------------------------
         * -1 after current hot bar slot is very important
         * ---------------------------------------------
         * */
        if (PlayerInventoryControllerScript.InventorySlotUsed[0, PlayerInventoryControllerScript.currentHotBarSlot -1])
        {
            PlayerInventoryControllerScript.amountOfItems--;
            //Debug.Log("Slot Num: " + SlotNum + "curRow: " + curRow+ "curCol: " + curCol);
            PlayerInventoryControllerScript.InventorySlots[0, PlayerInventoryControllerScript.currentHotBarSlot-1].transform.Find("ItemImg").GetComponent<Image>().enabled = false;
            PlayerInventoryControllerScript.InventorySlotUsed[0, PlayerInventoryControllerScript.currentHotBarSlot-1] = false;
            PlayerInventoryControllerScript.InventorySlotsItemName[0, PlayerInventoryControllerScript.currentHotBarSlot-1] = "";
            //PlayerInventoryControllerScript.UpdateHotbar();
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (PlayerInventoryControllerScript.currentHotBarSlot) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = false;
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("HotBar").Find("HotBarSlot (" + (PlayerInventoryControllerScript.currentHotBarSlot) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = null;
        }
    }


}
