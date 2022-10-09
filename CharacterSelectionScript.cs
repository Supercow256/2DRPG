using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionScript : MonoBehaviour
{
    GameObject CurrentPlayer;
    public static int CurrentCharacterNum;

    public static GameObject StevePreFab;
    public static GameObject DianaPreFab;
    public static GameObject GeorgePreFab;
    public static GameObject BoopPreFab;
    public static GameObject EggPreFab;
    public static GameObject GhostyPreFab;
    public static GameObject SkellyPreFab;

    public GameObject StevePreFab01;
    public  GameObject DianaPreFab01;
    public GameObject GeorgePreFab01;
    public GameObject BoopPreFab01;
    public GameObject EggPreFab01;
    public  GameObject GhostyPreFab01;
    public  GameObject SkellyPreFab01;

    public static bool switched;
    public static string CurrentCharacter;
    // Start is called before the first frame update
    void Start()
    {    
        StevePreFab = StevePreFab01;
        DianaPreFab = DianaPreFab01;
        GeorgePreFab = GeorgePreFab01;
        BoopPreFab = BoopPreFab01;
        EggPreFab = EggPreFab01;
        GhostyPreFab = GhostyPreFab01;
        SkellyPreFab = SkellyPreFab01;
        //switched = true;
}

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Canvas 03").GetComponent<Canvas>().enabled && (switched == false))
        {
            //image scale
            /*
            if (CurrentCharacterNum == 2)
            {
                transform.localScale = new Vector3(0.7f, 0.7f, 0f);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            */

            //characer image change
            if (CurrentCharacterNum == 0)
            {
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = StevePreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Steve";
                switched = true;
            }
            else if (CurrentCharacterNum == 1)
            {
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = DianaPreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Diana";
                switched = true;
            }
            else if (CurrentCharacterNum == 2)
            {
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = GeorgePreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "George";
                switched = true;
            }
            else if (CurrentCharacterNum == 3)
            {
                //Debug.Log(BoopPreFab.GetComponent<Image>().sprite);

                //Instantiate(BoopPreFab);
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = BoopPreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Boop";
                switched = true;
            }
            else if (CurrentCharacterNum == 4)
            {
                //Debug.Log(GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite);
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = EggPreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Egg";
                switched = true;
            }
            else if (CurrentCharacterNum == 5)
            {
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = GhostyPreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Ghosty";
                switched = true;
            }
            else if (CurrentCharacterNum == 6)
            {
                GameObject.Find("CurrentCharacterImage").GetComponent<Image>().sprite = SkellyPreFab.GetComponent<SpriteRenderer>().sprite;
                CurrentCharacter = "Skelly";
                switched = true;
            }
            else if (CurrentCharacterNum == -1)
            {
                CurrentCharacterNum = 6;
            }
            else if (CurrentCharacterNum == 7)
            {
                CurrentCharacterNum = 0;

            }

        }
    }
}
