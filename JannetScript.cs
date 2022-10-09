using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JannetScript : MonoBehaviour
{

    Text continueText;

    [Header ("UI Buttons")]
    [SerializeField] Button OpenShopButton;
    [SerializeField] Button GetHintButton;


    //[SerializeField] GameObject JannetsShop;

    int chatNum;
    // Start is called before the first frame update
    void Start()
    {

        continueText = transform.Find("SpeechUI").transform.Find("TextBox").transform.Find("ContinueText").GetComponent<Text>();
        //OpenShopButton.gameObject.transform.Get.enabled = false;
        OpenShopButton.gameObject.SetActive(false);
        //GetHintButton.gameObject.transform.enabled = false;
        GetHintButton.gameObject.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                chatNum++;
                if (chatNum == 0)
                {
                    JannetText("Hey, I'm Jannet!");
                }
                if (chatNum >= 1)
                {
                    JannetText("How Can I help you today?");
                    OpenShopButton.gameObject.SetActive(true);
                    GetHintButton.gameObject.SetActive(true);
                    continueText.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            transform.Find("SpeechUI").GetComponent<Canvas>().enabled = false;
            JannetText("Hey, I'm Jannet!");
            SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").GetComponent<JannetsShopScript>().CloseShop();
            chatNum = 0;
        }
    }

    public void OpenShop()
    {
        //Instantiate(JannetsShop, SpawnPlayers.MYPLAYER.transform.Find("HUD"));
        SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").GetComponent<JannetsShopScript>().OpenShop(SpawnPlayers.MYPLAYER.GetComponent<IShopCustomer>());
        //SpawnPlayers.MYPLAYER.transform.Find("HUD").transform.Find("JannetsShop").GetComponent<JannetsShopScript>().shopItemTemplate.gameObject.SetActive(false);
    }

    public void GiveHint()
    {

    }

    private void JannetText(string newText)
    {
        transform.Find("SpeechUI").transform.Find("TextBox").transform.Find("MainText").GetComponent<Text>().text = newText;
    }
}
