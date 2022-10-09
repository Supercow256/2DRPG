using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    //public InputField usernameInput;
    //public Text connectingText;
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    /*
    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            connectingText.enabled = true;
        }
    }
    */
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        //Debug.Log("Connected to Master");
        //SceneManager.LoadScene("Main");
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
        //Debug.Log("Joined Lobby");
    }
}
