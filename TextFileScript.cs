using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class TextFileScript : MonoBehaviour
{
    public static string myFilePath, fileName;

    public static string[] fileLines;
    public static string allString;
    public static string temp;
    public const string SAVE_FOLDER = "/saves/";
    // Start is called before the first frame update
    void Start()
    {

        fileName = "PlayerSettings.txt";

        // When Testing use this file path
        //myFilePath = Application.dataPath + "/txt Files/" + fileName;

        // When building use this file path
        myFilePath = "" + SAVE_FOLDER + fileName;
        //File.WriteAllText(myFilePath, "Character: Steve" + "/n" + "Character: Steve" + "/n");

        //new
        //fileLines = File.ReadAllLines(StartUpScreenButtonsScript.myFilePath);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public static void SaveCurrentLines()
    {
        fileLines = System.IO.File.ReadAllLines(myFilePath);
    }
    */
    /*
    public static void editLine(int index, string newText)
    {
        fileLines = System.IO.File.ReadAllLines(myFilePath);

        fileLines[index] = newText;
        for (int i = 0; i < fileLines.Length; i++)
        {
            allString += fileLines[i] + "\n";
        }
    }
    */
}
