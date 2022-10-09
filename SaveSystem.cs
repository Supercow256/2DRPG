using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public static class SaveSystem
{
    public static void Init()
    {
        if (!Directory.Exists(TextFileScript.SAVE_FOLDER))
        {
            Directory.CreateDirectory(TextFileScript.SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.WriteAllText(TextFileScript.myFilePath, saveString);
    }

    public static string Load()
    {
        if (File.Exists(TextFileScript.myFilePath))
        {
            string saveString = File.ReadAllText(TextFileScript.myFilePath);
            //GameObject.Find("Test Canvas").transform.Find("Text").GetComponent<Text>().text = saveString;
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
