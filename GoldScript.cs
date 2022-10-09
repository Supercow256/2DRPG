using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldScript : MonoBehaviour
{

    public int myGold;

    Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText = transform.Find("HUD").transform.Find("Gold").transform.Find("Text").GetComponent<Text>();
        UpdateGoldText();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */

    public int GetGold()
    {
        return myGold;
    }

    void UpdateGoldText()
    {
        goldText.text = "" + myGold;
    }

    public void AddGold(int gold)
    {
        myGold += gold;
        UpdateGoldText();
    }

    public void SpendGold(int gold)
    {
        myGold -= gold;
        UpdateGoldText();
    }
}
