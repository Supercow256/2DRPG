using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using Photon.Pun;
using Cinemachine;

public class CharacterController : MonoBehaviour, IShopCustomer
{

    //public XPScript XPBar;

    public GameObject Player;
    public Animator animator;
    public Rigidbody2D rb;
    //public GameObject[,] PlayerInventory = new GameObject[7,5];
    public static float speed = 5f;

    public bool inventoryOpen;
    public bool freezeCharacterController;
    public static string CurrentCharacter = "Steve";
    Vector2 movement;

    public PhotonView view;

    public int myPlayerNum;

    // MYPLAYER
    //public static GameObject MYPLAYER;
    // MYPLAYER


    //public GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //MYPLAYER = SpawnPlayers.GetMYPLAYER(view);
        CurrentCharacter = CharacterSelectionScript.CurrentCharacter;

        //view.RPC("ChangeCharacterSprite", RpcTarget.All, Player, GetCharacter(CurrentCharacter));
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            Destroy(GetComponent<PhotonView>());
            Destroy(GetComponent<PhotonTransformViewClassic>());
            Destroy(GetComponent<PhotonTransformView>());
            Destroy(GetComponent<PhotonAnimatorView>());
            Destroy(GetComponent<PhotonRigidbody2DView>());
        }
        if (StartUpScreenButtonsScript.singlePlayerBool || view.IsMine)
        {
            //Debug.Log("I AM IN THE THING");
            //PlayerManager.LocalPlayerInstance = this.gameObject;
            //Debug.Log("IS MINE");
            Player = this.gameObject;
            SaveSystem.Init();
            if (CurrentCharacter == null)
            {
                CurrentCharacter = "Steve";
            }
            //Debug.Log("" + CurrentCharacter);
            LoadCharacter(CurrentCharacter);
            inventoryOpen = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Escape))
        {
            GameHandlerScript.ExitGame();
        }
        */
        if ((StartUpScreenButtonsScript.singlePlayerBool || view.IsMine) && (freezeCharacterController == false))
        {

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x > 0) animator.SetBool("LastVerticalMovement", true);
            else animator.SetBool("LastVerticalMovement", false);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
            {
                inventoryOpen = !inventoryOpen;
                if (!inventoryOpen)
                {
                    //Inventroy.Open();
                }
            }

            //PhotonNetwork.RPC("RPC_UpdatePlayerSprite", RPCTarget.Others);
        }

    }

    void FixedUpdate()
    {
        if (StartUpScreenButtonsScript.singlePlayerBool ||  view.IsMine)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }
   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.name == "scithersword")
        //{
        if (other.tag == "Item")
        {
            PlayerInventoryControllerScript.GetNameOfCollider(other.name);
            PlayerInventoryControllerScript.AddItemToInventory(other.gameObject);
        }
        //PlayerInventoryControllerScript.UpdateHotbar();
        //Debug.Log("boop");
        //GameObject.Find(other.name).GetComponent<SpriteRenderer>().sprite



        // need to add scithersword to inventory
        // take the gameobject attached to the slot and change the icon
        //PlayerInventoryControllerScript.InventorySlots[0, 0].GetChild(0).GetChild(0).Image.SourceImage = 
        //other.SpriteRenderer.Sprite;
        //}
    }
    
    public void LoadCharacter(string Character)
    {

        CurrentCharacter = Character;
        Player.GetComponent<SpriteRenderer>().sprite = GetCharacter(Character).transform.GetComponent<SpriteRenderer>().sprite;
        Player.transform.GetComponent<Animator>().runtimeAnimatorController = GetCharacter(Character).transform.GetComponent<Animator>().runtimeAnimatorController;
        //broadcast change to server
        if (StartUpScreenButtonsScript.singlePlayerBool == false)
        {
            view.RPC("ChangeCharacterSprite", RpcTarget.All, SpawnPlayers.MYPLAYER, GetCharacter(Character));
        }
    }

    [PunRPC]
    void ChangeCharacterSprite(GameObject _Player, GameObject _CharacterPreFab)
    {
        Debug.Log("Should update sprite");
        _Player.GetComponent<SpriteRenderer>().sprite = _CharacterPreFab.transform.GetComponent<SpriteRenderer>().sprite;
        _Player.transform.GetComponent<Animator>().runtimeAnimatorController = _CharacterPreFab.transform.GetComponent<Animator>().runtimeAnimatorController;
    }

    /*
    [PunRPC]
    void ChangeCharacterSprite(GameObject _Player, GameObject _CharacterPreFab) 
    {
        _Player.GetComponent<SpriteRenderer>().sprite = _CharacterPreFab.transform.GetComponent<SpriteRenderer>().sprite;
        _Player.transform.GetComponent<Animator>().runtimeAnimatorController = _CharacterPreFab.transform.GetComponent<Animator>().runtimeAnimatorController;
    }
    */

    public static GameObject GetCharacter(string characterString)
    {
        if (characterString.Equals("Steve"))
        {
            CharacterController.CurrentCharacter = "Steve";
            return CharacterSelectionScript.StevePreFab;
        }
        else if (characterString.Equals("Diana"))
        {
            CharacterController.CurrentCharacter = "Diana";
            return CharacterSelectionScript.DianaPreFab;
        }
        else if (characterString.Equals("George"))
        {
            CharacterController.CurrentCharacter = "George";
            return CharacterSelectionScript.GeorgePreFab;
        }
        else if (characterString.Equals("Boop"))
        {
            CharacterController.CurrentCharacter = "Boop";
            return CharacterSelectionScript.BoopPreFab;
        }
        else if (characterString.Equals("Egg"))
        {
            CharacterController.CurrentCharacter = "Egg";
            return CharacterSelectionScript.EggPreFab;
        }
        else if (characterString.Equals("Ghosty"))
        {
            CharacterController.CurrentCharacter = "Ghosty";
            return CharacterSelectionScript.GhostyPreFab;
        }
        else if (characterString.Equals("Skelly"))
        {
            CharacterController.CurrentCharacter = "Skelly";
            return CharacterSelectionScript.SkellyPreFab;
        }
        //CurrentCharacter = "Steve";
        return CharacterSelectionScript.StevePreFab;
    }

    public static Sprite GetCharacterDead(string characterString)
    {
        if (characterString.Equals("Steve"))
        {
            // 2
            return DeadCharacters.SteveDeadUpSprite;
        }
        else if (characterString.Equals("Diana"))
        {
            // 2
            return DeadCharacters.DianaDeadUpSprite;
        }
        else if (characterString.Equals("George"))
        {
            // does not have one yet
            return DeadCharacters.SteveDeadDownSprite;
        }
        else if (characterString.Equals("Boop"))
        {
            return DeadCharacters.BoopDeadSprite;
        }
        else if (characterString.Equals("Egg"))
        {
            // 2
            return DeadCharacters.EggDeadUpSprite;
        }
        else if (characterString.Equals("Ghosty"))
        {
            return DeadCharacters.GhostyDeadSprite;
        }
        else if (characterString.Equals("Skelly"))
        {
            return DeadCharacters.SkellyDeadSprite;
        }
        //CurrentCharacter = "Steve";
        return DeadCharacters.SteveDeadDownSprite;
    }

    public void BoughtItem(GameObject Prefab, string itemName, string listType)
    {
        if (listType.Equals("PetsList"))
        {
            GameObject petText = GameObject.Find("MyPet").transform.Find("NameCanvas").transform.Find("Text").gameObject;
            double textNewY = ItemsScript.PetsList.Find(v => v.name == itemName).textPos + petText.transform.position.y;
            GameObject.Find("MyPet").GetComponent<SpriteRenderer>().sprite = Prefab.GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("MyPet").GetComponent<Animator>().runtimeAnimatorController = Prefab.GetComponent<Animator>().runtimeAnimatorController;
            petText.transform.position = new Vector3 (petText.transform.position.x, (float)(textNewY), petText.transform.position.z); 
        }
        else
        {
            Instantiate(Prefab, this.gameObject.transform.position, Quaternion.identity);
        }
        //Debug.Log("Bought Item: " + Prefab.name);
    }

    public bool TrySpendingGoldAmount(int spendGoldAmount)
    {
        if(SpawnPlayers.MYPLAYER.GetComponent<GoldScript>().GetGold() > spendGoldAmount)
        {

            SpawnPlayers.MYPLAYER.GetComponent<GoldScript>().SpendGold(spendGoldAmount);
            //OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}
