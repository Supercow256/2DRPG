using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{


    public EnemyHealthBarScript healthBar;

    [Header ("Enemy Vars")]
    [SerializeField] float coolDown;
    [SerializeField] int baseDamage;
    [SerializeField] int baseHealth = 10;
    [SerializeField] int baseXP;
    [SerializeField] int maxHealth;
    [SerializeField] public int level;
    [SerializeField] int currentHealth;
    [SerializeField] bool dropItem;
    [SerializeField] GameObject dropItemPreFab;
    [SerializeField] int baseGoldDropped;
    private float time;
    int goldDropped;
    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        //coolDown = tempCoolDown;
        //baseDamage = tempBaseDamage;
        time = coolDown;
        maxHealth = baseHealth + (level * 5);
        goldDropped = baseGoldDropped + (level * 5);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.Find("Level").transform.Find("Text").GetComponent<Text>().text = "" + level;
    }

    void Update()
    {
        if (Vector2.Distance(SpawnPlayers.MYPLAYER.transform.position, transform.position) <= 1.0f && time > coolDown)
        {
            //Debug.Log("attacked");
            Attack();
            time = 0f;
        }
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        PlayerCombatScript.currentHealth -= baseDamage;
        //Debug.Log("Players health is: " + PlayerCombatScript.currentHealth);
    }

    void Die()
    {

        // drop item if activated 

        if (dropItem)
        {
            Instantiate(dropItemPreFab, transform.position, Quaternion.identity);
        }
        //Debug.Log("died");
        //play die animation

        // Give Player XP
        SpawnPlayers.MYPLAYER.GetComponent<XPScript>().GainXP((int)(baseXP*level));

        // Give Player Gold
        SpawnPlayers.MYPLAYER.GetComponent<GoldScript>().AddGold(goldDropped);

        // disable the enemy
        Destroy(gameObject);
    }
}
