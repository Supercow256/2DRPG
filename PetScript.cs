using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetScript : MonoBehaviour
{

    [Header("Pet Settings")]
    [SerializeField] public string petName;
    public int baseMaxHealth;
    public bool isHostile;
    public int baseAttack;

    public float coolDown;

    //public EnemyHealthBarScript healthBar;

    //public int baseHealth = 10;
    //public int baseXP;
    //public int maxHealth;
    //public int level;
    //public int currentHealth;
    //public bool dropItem;
    //public GameObject dropItemPreFab;
    private float time;

    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        //coolDown = tempCoolDown;
        //baseDamage = tempBaseDamage;
        //time = coolDown;
        //maxHealth = baseHealth + (level * 5);
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        //transform.Find("Level").transform.Find("Text").GetComponent<Text>().text = "" + level;
    }

    void Update()
    {
        /*
        if (Vector2.Distance(SpawnPlayers.MYPLAYER.transform.position, transform.position) <= 1.0f && time > coolDown)
        {
            //Debug.Log("attacked");
            Attack();
            time = 0f;
        }
        */
    }

    void FixedUpdate()
    {
        //time += Time.deltaTime;
    }

    public void ChangePetName(string newName)
    {
        petName = newName;
        transform.Find("NameCanvas").transform.Find("Text").GetComponent<Text>().text = petName;
    }

}
