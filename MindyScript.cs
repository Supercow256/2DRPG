using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MindyScript : MonoBehaviour
{

    Text continueText;

    [Header("UI Buttons")]
    [SerializeField] Button OpenShopButton;
    [SerializeField] Button ChangePetNameButton;
    [SerializeField] Button SubmitNameButton;
    [SerializeField] InputField ChangePetNameInput;


    int chatNum;
    bool moveOn;
    bool temp;
    bool run;
    // Start is called before the first frame update
    void Start()
    {
        run = false;
        moveOn = true;
        continueText = transform.Find("SpeechUI").transform.Find("TextBox").transform.Find("ContinueText").GetComponent<Text>();
        OpenShopButton.gameObject.SetActive(false);
        ChangePetNameButton.gameObject.SetActive(false);
        SubmitNameButton.gameObject.SetActive(false);
        ChangePetNameInput.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if ((SpawnPlayers.MYPLAYER.transform.position.x < transform.position.x + 3) &&
        (SpawnPlayers.MYPLAYER.transform.position.x > transform.position.x - 3) &&
        (SpawnPlayers.MYPLAYER.transform.position.y < transform.position.y + 3) &&
        (SpawnPlayers.MYPLAYER.transform.position.y > transform.position.y - 3))
        {
            transform.Find("SpeechUI").GetComponent<Canvas>().enabled = true;
            if ((Input.GetKeyDown(KeyCode.E) || run) && moveOn)
            {
                chatNum++;
                if (chatNum == 0)
                {
                    MindyText("Hey there, Im Mindy!");
                }
                if (chatNum == 1)
                {
                    moveOn = false;
                    MindyText("I can help you with anything pets related!");
                    OpenShopButton.gameObject.SetActive(true);
                    ChangePetNameButton.gameObject.SetActive(true);
                    continueText.gameObject.SetActive(false);
                }
                if (chatNum == 2 && temp == true)
                {
                    //if temp true then shop openned
                    OpenShopButton.gameObject.SetActive(false);
                    ChangePetNameButton.gameObject.SetActive(false);
                    MindyText("Happy Shopping!");
                }
                else if (chatNum == 3 && temp == false)
                {
                    // if temp is false then change pet name is openned
                    OpenShopButton.gameObject.SetActive(false);
                    ChangePetNameButton.gameObject.SetActive(false);
                    MindyText("What would you like to change your pets name to?");
                }
            }
            run = false;
        }
        else
        {
            transform.Find("SpeechUI").GetComponent<Canvas>().enabled = false;
            MindyText("Hey there, Im Mindy!");
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("MindysShop").GetComponent<MindysShopScript>().CloseShop();
            //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").GetComponent<JannetsShopScript>().CloseShop();
            chatNum = 0;
            OpenShopButton.gameObject.SetActive(false);
            ChangePetNameButton.gameObject.SetActive(false);
            SubmitNameButton.gameObject.SetActive(false);
            ChangePetNameInput.gameObject.SetActive(false);
        }
    }

    private void MindyText(string newText)
    {
        transform.Find("SpeechUI").transform.Find("TextBox").transform.Find("MainText").GetComponent<Text>().text = newText;
    }

    public void OpenShop()
    {
        moveOn = true;
        chatNum++;
        temp = true;
        //Instantiate(JannetsShop, SpawnPlayers.MYPLAYER.transform.Find("HUD"));
        SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("MindysShop").GetComponent<MindysShopScript>().OpenShop(SpawnPlayers.MYPLAYER.GetComponent<IShopCustomer>());
        //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").GetComponent<JannetsShopScript>().OpenShop(SpawnPlayers.MYPLAYER.GetComponent<IShopCustomer>());
    }

    public void OnChangePetName()
    {
        GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().FreezeAll();
        //SpawnPlayers.MYPLAYER.GetComponent<CharacterController>().freezeCharacterController = true;
        moveOn = false;
        chatNum++;
        temp = false;
        OpenShopButton.gameObject.SetActive(false);
        ChangePetNameButton.gameObject.SetActive(false);

        ChangePetNameInput.gameObject.SetActive(true);
        SubmitNameButton.gameObject.SetActive(true);
    }

    public void OnSubmitName()
    {
        continueText.gameObject.SetActive(true);
        GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().ResumeAll();
        GameObject.Find("MyPet").GetComponent<PetScript>().ChangePetName(ChangePetNameInput.text);
        //SpawnPlayers.MYPLAYER.GetComponent<CharacterController>().freezeCharacterController = false;
        chatNum = 1;
        run = true;
        moveOn = true;
    }
}
