using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameHandlerScript : MonoBehaviour
{
    [Header("Mini Games")]
    [SerializeField] public GameObject FishingGame;

    public static bool fishingGameIsOpen;

    //public GameObject CharacterPrefab;
    void Awake()
    {
        // SET HUD SHOPS TO INACTIVE
        //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").gameObject.SetActive(false);
        //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("MindysShop").gameObject.SetActive(false);

        //MultiPlayers = PhotonNetwork.PlayerList;
        /*
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);

        }
        */
    }

    public void StartFishing(/*GameObject parent*/)
    {
        GameObject temp;
        if (!fishingGameIsOpen)
        {
            temp = Instantiate(FishingGame, new Vector3(SpawnPlayers.MYPLAYER.transform.position.x - 2.5f, SpawnPlayers.MYPLAYER.transform.position.y - 2.5f, 0f), Quaternion.identity);
            //temp.transform.parent = parent.transform;
            fishingGameIsOpen = true;
        }
    }
    
    public void FreezeAll()
    {
        SpawnPlayers.MYPLAYER.GetComponent<CharacterController>().freezeCharacterController = true;
        SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().freeze = true;
    }

    public void ResumeAll()
    {
        SpawnPlayers.MYPLAYER.GetComponent<CharacterController>().freezeCharacterController = false;
        SpawnPlayers.MYPLAYER.GetComponent<PlayerInventoryControllerScript>().freeze = false;
    }

    /*
    public void TestButton()
    {
        GameObject.Find("Test Canvas").transform.Find("Text").GetComponent<Text>().text = "test Button";
       Instantiate(Resources.Load<GameObject>(ItemsScript.A.Find(v => v.name == "scitherSword").preFabPath), Vector3.zero, Quaternion.identity);

    }
    */
    public void Save()  
    {
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            SaveObject saveObject = new SaveObject
            {
                character = CharacterController.CurrentCharacter,
                characterPosition = SpawnPlayers.MYPLAYER.transform.position,
                questNum = BobbyScript.currentQuestNum,
                saveInventoryItemsNames = new string[28],
                saveInventorySlots = new GameObject[28],
                saveInventorySlotsUsed = new bool[28],
                saveInventoryImages = new Sprite[28],
                saveAmountItems = PlayerInventoryControllerScript.amountOfItems,
                MaxHealth = PlayerCombatScript.maxHealth,
                currentLevel = XPScript.level,
                XPNeeded = XPScript.XPNeeded,
                currentXP = XPScript.currentXP,
                myGold = SpawnPlayers.MYPLAYER.GetComponent<GoldScript>().myGold,
                //petName = GameObject.Find("MyPet").GetComponent<PetScript>().petName,
                //petAnimator = GameObject.Find("MyPet").GetComponent<Animator>(),
                //petSprite = GameObject.Find("MyPet").GetComponent<SpriteRenderer>().sprite
            };
            saveObject.saveInventory();
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }
    }
    public void Load()
    {
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            //GameObject.Find("Test Canvas").transform.Find("Text").GetComponent<Text>().text = "this is in load";
            string saveString = SaveSystem.Load();
            if (saveString != null)
            {
                //GameObject.Find("Test Canvas").transform.Find("Text").GetComponent<Text>().text = "savestring != null";
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                //CharacterController.LoadCharacter(saveObject.character);
                SpawnPlayers.MYPLAYER.transform.position = saveObject.characterPosition;
                BobbyScript.currentQuestNum = saveObject.questNum;
                PlayerCombatScript.maxHealth = saveObject.MaxHealth;
                //set XP Bar
                XPScript.SetXP(saveObject.currentLevel, saveObject.currentXP, saveObject.XPNeeded);

                SpawnPlayers.MYPLAYER.GetComponent<GoldScript>().AddGold(saveObject.myGold);
                //GameObject.Find("MyPet").GetComponent<PetScript>().ChangePetName(saveObject.petName);
                //GameObject.Find("MyPey").GetComponent<SpriteRenderer>().sprite = saveObject.petSprite;
                //GameObject.Find("MyPet").GetComponent<Animator>().runtimeAnimatorController = saveObject.petAnimator.runtimeAnimatorController;
                // transfer saved inventory to current
                PlayerInventoryControllerScript.amountOfItems = saveObject.saveAmountItems;
                for (int i = 0; i < 28; i++)
                {
                    PlayerInventoryControllerScript.InventorySlotsItemName[i / 7, i % 7] = saveObject.saveInventoryItemsNames[i];
                    PlayerInventoryControllerScript.InventorySlots[i / 7, i % 7] = saveObject.saveInventorySlots[i];
                    PlayerInventoryControllerScript.InventorySlotUsed[i / 7, i % 7] = saveObject.saveInventorySlotsUsed[i];
                    if (saveObject.saveInventorySlotsUsed[i] == true)
                    {
                        PlayerInventoryControllerScript.InventorySlots[i / 7, i % 7].transform.Find("ItemImg").GetComponent<Image>().sprite = saveObject.saveInventoryImages[i];
                        PlayerInventoryControllerScript.InventorySlots[i / 7, i % 7].transform.Find("ItemImg").GetComponent<Image>().enabled = true;
                        if (i < 7)
                        {
                            GameObject.Find("HUD").transform.Find("HotBar").transform.Find("HotBarSlot (" + (i + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().sprite = saveObject.saveInventoryImages[i];
                            GameObject.Find("HotBarSlot (" + (i + 1) + ")").transform.Find("ItemImg").GetComponent<Image>().enabled = true;

                        }
                    }
                }

                //saveObject.getInventory();
            }
        }
       
        
    }
    public class SaveObject
    {
        public string character;
        public Vector3 characterPosition;
        public int questNum;
        public string[] saveInventoryItemsNames;
        public GameObject[] saveInventorySlots;
        public bool[] saveInventorySlotsUsed;
        public Sprite[] saveInventoryImages;
        public int saveAmountItems;
        public int MaxHealth;
        public int currentLevel;
        public int XPNeeded;
        public int currentXP;
        public int myGold;

        // pet saving
        public string petName;
        public Sprite petSprite;
        // might throw error
        public Animator petAnimator;
        //public runtimeAnimatorController = petAnimatorController;
        // might throw error

        public void saveInventory()
        {
            if (StartUpScreenButtonsScript.singlePlayerBool)
            {
                for (int i = 0; i < 28; i++)
                {
                    saveInventoryItemsNames[i] = PlayerInventoryControllerScript.InventorySlotsItemName[i / 7, i % 7];
                    saveInventorySlots[i] = PlayerInventoryControllerScript.InventorySlots[i / 7, i % 7];
                    saveInventorySlotsUsed[i] = PlayerInventoryControllerScript.InventorySlotUsed[i / 7, i % 7];
                    saveInventoryImages[i] = PlayerInventoryControllerScript.InventorySlots[i / 7, i % 7].transform.Find("ItemImg").GetComponent<Image>().sprite;
                }
            }

        }

    }

    public void ExitGame()
    {
        //prompt confirmation script
        Application.Quit();
    }
}
