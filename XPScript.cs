using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPScript : MonoBehaviour
{

    public static Slider slider;
    public static Text levelText;

    public static int level;
    public static int XPNeeded;
    public static int currentXP;
    

    void Start()
    {
        levelText = transform.Find("HUD").transform.Find("XPBar").transform.Find("Level").GetComponent<Text>();
        slider = transform.Find("HUD").transform.Find("XPBar").GetComponent<Slider>();
        level = 1;
        XPNeeded = 50;
        slider.maxValue = XPNeeded;
        currentXP = 0;
        slider.value = currentXP;
        
    }

    /*
    void Update()
    {
        if (currentXP >= XPNeeded)
            LevelUp();
    }
    */

    public void GainXP (int experience)
    {
        currentXP += experience;
        if (currentXP >= XPNeeded)
            LevelUp();
        else
            slider.value = currentXP;
    }

    public void LevelUp()
    {
        level++;
        levelText.text = "" + level;
        XPNeeded += 20;
        slider.maxValue = XPNeeded;
        currentXP = 0;
        slider.value = currentXP;
        PlayerCombatScript.maxHealth += 10;
    }

    public static void SetXP(int curLevel, int current, int needed)
    {
        level = curLevel;
        currentXP = current;
        XPNeeded = needed;
        levelText.text = "" + level;
        slider.maxValue = XPNeeded;
        slider.value = currentXP;
    }

}
