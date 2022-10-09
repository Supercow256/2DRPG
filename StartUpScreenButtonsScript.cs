using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartUpScreenButtonsScript : MonoBehaviour
{
    
    public static string myFilePath, fileName;
    public static bool singlePlayerBool = false;
    void Awake()
    {
        GameObject.Find("Canvas 01").GetComponent<Canvas>().enabled = true;
        GameObject.Find("Canvas 02").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas 03").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas 04").GetComponent<Canvas>().enabled = false;

        fileName = "PlayerSettings.txt";

        // When Testing use this file path
        //myFilePath = Application.dataPath + "/txt Files/" + fileName;

        // When building use this file path
        myFilePath = fileName;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void StartButton()
    {
        GameObject.Find("Canvas 01").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas 02").GetComponent<Canvas>().enabled = true;

    }

    public void SelectCharacterButton()
    {
        GameObject.Find("Canvas 02").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas 03").GetComponent<Canvas>().enabled = true;
    }

    public static void NextCharacter()
    {
        CharacterSelectionScript.switched = false;
        CharacterSelectionScript.CurrentCharacterNum++;
    }

    public static void PreviousCharacter()
    {
        CharacterSelectionScript.switched = false;
        CharacterSelectionScript.CurrentCharacterNum--;
    }

    public static void SinglePlayer()
    {
        singlePlayerBool = true;
        SceneManager.LoadScene("Main");
    }

    public static void MultiPlayer()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public static void SelectButton()
    {
        GameObject.Find("Canvas 03").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas 04").GetComponent<Canvas>().enabled = true;
        //.editLine(0, "Character: " + CharacterSelectionScript.CurrentCharacter);
    }
}
