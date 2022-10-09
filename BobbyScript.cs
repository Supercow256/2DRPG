using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BobbyScript : MonoBehaviour
{

    [Header("Instantiated Items")]
    [SerializeField] GameObject Starter_Rod_preFab;

    public static bool QuestCompleted;
    public static int currentQuestNum;

    int chatNum;
    bool moveOn;
    //private bool justWalkedUp;
    // Start is called before the first frame update
    void Start()
    {
        currentQuestNum = 1;
    }

    // Update is called once per frame
    void Update()
    {

        // If close to NPC
        if ((SpawnPlayers.MYPLAYER.transform.position.x < transform.position.x + 3) &&
            (SpawnPlayers.MYPLAYER.transform.position.x > transform.position.x - 3) &&
            (SpawnPlayers.MYPLAYER.transform.position.y < transform.position.y + 3) &&
            (SpawnPlayers.MYPLAYER.transform.position.y > transform.position.y - 3))
        {
            transform.Find("SpeechUI").GetComponent<Canvas>().enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                chatNum++;
                //Debug.Log(chatNum + "," + currentQuestNum);
                if (currentQuestNum == 1)
                {
                    if (chatNum < 2)
                    {
                        BobbyText("Hello, my name is Bobby. I'll help you get started!");
                    }
                    if (chatNum == 2)
                    {
                        BobbyText("Your First task will be to go through those item on the floor over there and pick up the Scither Sword.");
                    }
                    else if (chatNum == 3)
                    {
                        if (FindInInventory("scitherSword"))
                        {
                            BobbyText("You have the sword");
                            currentQuestNum++;
                            chatNum = 1;
                        }
                        else
                        {
                            BobbyText("You do not have the sword");
                        }
                    }
                }
                if (currentQuestNum == 2)
                {
                    if (chatNum == 1)
                        BobbyText("Now That you have a sword to defend yourself...");
                    if (chatNum == 3)
                    {
                        BobbyText("Take the path all the way to the right and get me a carp (it's a red fish)...");
                    }
                    if (chatNum == 4)
                    {
                        BobbyText("Here take this fishing rod, It's not the best but it should do the trick");
                        Instantiate(Starter_Rod_preFab, transform.position, Quaternion.identity);
                    }
                    else if (chatNum == 5)
                    {
                        if (FindInInventory("Carp"))
                        {
                            BobbyText("Thank you!!! Now I can make my world renowned soup.");
                            FindInventorySlotContaining("Carp").GetComponent<InventorySlotScript>().RemoveItem();
                            moveOn = true;
                            // THIS WILL BUG IF WALKED AWAY
                            //if (chatNum == 4 )
                            //{
                            //    currentQuestNum++;
                            //    chatNum = 1;
                            //}
                            // THIS WILL BUG IF WALKED AWAY
                        }
                        else
                        {
                            BobbyText("Come back to me when you have a carp.");
                        }
                    }
                    // THIS WIL BUG
                    if (chatNum == 4 && moveOn)
                    {
                        currentQuestNum++;
                        chatNum = 1;
                    }
                    // THIS WILL BUG
                }
                if (currentQuestNum == 3)
                {
                    if (chatNum == 1)
                        BobbyText("You are on quest number 3");
                }
            }
        }
        else
        {
            transform.Find("SpeechUI").GetComponent<Canvas>().enabled = false;
            BobbyText("Hey there, Press E to chat!");
            chatNum = 0;
        }
    }
    /*
    void FixedUpdate()
    {
        if (transform.Find("BobbySpeechUI").transform.Find("TextBox").transform.Find("MainText").GetComponent<Text>().text.length > 40)
        {

        }
    }
    */
    private void BobbyText(string newText)
    {
        transform.Find("SpeechUI").transform.Find("TextBox").transform.Find("MainText").GetComponent<Text>().text = newText;
    }

    private bool FindInInventory(string itemName)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (PlayerInventoryControllerScript.InventorySlotsItemName[i, j] == itemName || PlayerInventoryControllerScript.InventorySlotsItemName[i, j] == (itemName + "(Clone)"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private GameObject FindInventorySlotContaining(string itemName)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (PlayerInventoryControllerScript.InventorySlotsItemName[i, j] == itemName || PlayerInventoryControllerScript.InventorySlotsItemName[i, j] == (itemName + "(Clone)"))
                {
                    return PlayerInventoryControllerScript.InventorySlots[i, j];
                }
            }
        }
        return null;
    }

    /*
    private bool FindInInventory(string itemName, int quantity)
    {

    }
    */
}