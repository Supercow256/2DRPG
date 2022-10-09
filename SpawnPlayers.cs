using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject PlayerTemp;
    //public PhotonView view;

    public static GameObject[] MultiPlayers = new GameObject[5];
    public static int amountOfPlayers = 0;

    public static GameObject MYPLAYER;

    /*
    public static GameObject GetMYPLAYER(PhotonView tempView)
    {
        foreach (GameObject p in MultiPlayers)
        {
            if (p.GetComponent<CharacterController>().view.ViewID == tempView.ViewID)
            {
                return p;
                //Debug.Log("I HAVE FOUND MY PLAYER, THE NAME IS: " + MYPLAYER.GetComponent<SpriteRenderer>().sprite);

            }   
        }
        return null;

    }
    */
    private void Awake() {

        if (StartUpScreenButtonsScript.singlePlayerBool == false)
        {
            PlayerTemp = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            PlayerTemp.GetComponent<CharacterController>().view = PlayerTemp.GetComponent<PhotonView>();
            PlayerTemp.GetComponent<CharacterController>().myPlayerNum = amountOfPlayers;
            MYPLAYER = PlayerTemp;
            //MYPLAYER = CharacterController.view.Find(PlayerTemp.GetComponent<PhotonView>().ViewID).transform.gameobject;
            MultiPlayers[amountOfPlayers] = PlayerTemp;
            amountOfPlayers++;

            foreach (GameObject p in MultiPlayers)
            {
                if (p.GetComponent<CharacterController>().view.IsMine)
                {
                    MYPLAYER = p;
                    //Debug.Log("I HAVE FOUND MY PLAYER, THE NAME IS: " + MYPLAYER.GetComponent<SpriteRenderer>().sprite);
                    GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = MYPLAYER.transform;
                    GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = MYPLAYER.transform;

                }
            }
        }
        else
        {
            MYPLAYER = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            MYPLAYER.GetComponent<CharacterController>().view = null;
            MYPLAYER.GetComponent<CharacterController>().myPlayerNum = amountOfPlayers;
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = MYPLAYER.transform;
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = MYPLAYER.transform;
        }
        
        

        
        /*
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList.IsLocal)
            {
                MYPLAYER = PhotonNetwork.PlayerList[i];
            }
            else
            {
                //Do something else or return
            }
        }
        */

        //PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);    
        /*
        if (StartUpScreenButtonsScript.singlePlayerBool == false)
        {
            //instantiate character
            PlayerTemp = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);

            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = PlayerTemp.transform;
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = PlayerTemp.transform;
        }
        else {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        }
        */

        /*
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        */
        /*
        if (StartUpScreenButtonsScript.singlePlayerBool == false)
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        */
    }

}
