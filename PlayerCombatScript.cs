using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemsScript;

public class PlayerCombatScript : MonoBehaviour
{
    [Header("Health settings")]
    public static int maxHealth;
    public static int currentHealth;
    public PlayerHealthScript playerHealthBar;

    [Header("Attack Settings")]
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float knockbackTime = 0.3f;
    
    [Header("Start Fishing Settings")]
    public LayerMask waterLayer;

    //float healthCounter;
    float strengthTimer;
    float speedTimer;
    float throwTimer;

    //public XPScript XPBar;
    void Start()
    {
        playerHealthBar = transform.Find("HUD").transform.Find("HealthBar").GetComponent<PlayerHealthScript>();
        transform.Find("HUD").transform.Find("Effects").transform.Find("Text").GetComponent<Text>().enabled = false;
        maxHealth = 200;
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);
        playerHealthBar.SetHealth(currentHealth);
        playerHealthBar.SetHealthText(currentHealth, maxHealth);
        //Debug.Log(ItemsScript.A.Find(v => v.name == "scitherSword").damageType);

    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.SetMaxHealth(maxHealth);
        if (currentHealth <=0)
        {
            currentHealth = 0;
            StartCoroutine(Die());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PlayerInventoryControllerScript.nameOfHeldItem);
            StartCoroutine(showHand());
            if (MeleeWeaponsList.Contains(MeleeWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem)))
            {
                MeleeAttack();
            }
            else if (ThrowableWeaponsList.Contains(ThrowableWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem)))
            {
                //StartCoroutine(Throw());
            }
            else if (ConsumableList.Contains(ConsumableList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem)))
            {
                //InventorySlotScript.RemoveHotBarItem();
                Consume();
            }
            else if (FishingRodsList.Contains(FishingRodsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem)))
            {
                Fish(); 
            }
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealthBar.SetHealth(currentHealth);
        playerHealthBar.SetHealthText(currentHealth, maxHealth);
    }

    void FixedUpdate()
    {
        speedTimer -= Time.deltaTime;
        throwTimer += Time.deltaTime;

        if (speedTimer < 0)
        {
            CharacterController.speed = 5f;
        }
    }

    IEnumerator showHand()
    {
        SpawnPlayers.MYPLAYER.transform.Find("Character Hand").GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1);
        //Debug.Log("Show Hand");
        SpawnPlayers.MYPLAYER.transform.Find("Character Hand").GetComponent<SpriteRenderer>().enabled = false;
    }

    void MeleeAttack()
    {

        //do not change for now
        //int knockbackTime = 4;
        //do not change for now

        // get weapon stats
        int knockbackPower = MeleeWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).knockbackPower;
        // play animation 

        // Find enemies in weapon rang
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, MeleeWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).range, enemyLayers);
        // damage them with weapon stats
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>().TakeDamage(MeleeWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).baseDamage);
            // knockback enemy
            //--------
            // /*
            Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
            if(enemyRB != null)
            {
                enemyRB.bodyType = RigidbodyType2D.Kinematic;
                enemyRB.isKinematic = false;
                Vector2 difference = enemyRB.transform.position - transform.position;
                difference = (difference.normalized) * knockbackPower;
                enemyRB.AddForce(difference, ForceMode2D.Impulse);
                
                StartCoroutine(KnockbackEnemy(enemyRB));
            }
            // */
            //-----
        }
    }

    /*
    IEnumerator Throw()
    {
        Debug.Log("in throw");
        Vector3 startingPos = transform.Find("Character Hand").transform.position;
        float throwForce = 100f;
        int knockbackPower = ThrowableWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).knockbackPower;
        throwTimer = 0f;
        float setTime = 2.0f;
        Vector3 throwDirection;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, ThrowableWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).range, enemyLayers);
        SpawnPlayers.MYPLAYER.transform.Find("Character Hand").GetComponent<SpriteRenderer>().enabled = true;
        if (hitEnemies[0] != null)
        {
            throwDirection = (hitEnemies[0].transform.position - transform.position).normalized;
            SpawnPlayers.MYPLAYER.transform.Find("Character Hand").GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

            Debug.Log("Going to enemy");
            yield return new WaitForSeconds(2);
        }
        else
        {
            throwDirection = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            Debug.Log("Just going");
            yield return new WaitForSeconds(2);
        }
        //Instantiate(PlayerInventoryControllerScript.InventorySlots[0, PlayerInventoryControllerScript.currentHotBarSlot -1].GetComponent<InventorySlotScript>().itemGameObject, transform.position, Quaternion.identity);
        transform.Find("Character Hand").transform.position = startingPos;
    }
    */

    private IEnumerator KnockbackEnemy(Rigidbody2D enemyRB)
    {
        if (enemyRB != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            enemyRB.velocity = Vector2.zero;
            enemyRB.isKinematic = true;
            enemyRB.bodyType = RigidbodyType2D.Dynamic;
        }

    }

    void Consume()
    {
        //Debug.Log("In Consume");
        string effect = ConsumableList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).effect;
        int strength = ConsumableList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).strength;
        float duration = ConsumableList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).duration;

        if (effect.Equals("Heal") && currentHealth!= maxHealth)
        {
            currentHealth += strength;
            InventorySlotScript.RemoveHotBarItem();
        }
        else if (effect.Equals("Speed"))
        {
            //Debug.Log("in speed");
            //GameObject.Find("HUD").transform.Find("Effects").transform.Find("Text").GetComponent<Text>().text = "speed";
            //GameObject.Find("HUD").transform.Find("Effects").transform.Find("Text").GetComponent<Text>().enabled = true;
            CharacterController.speed = strength;
            if (speedTimer < 0)
            {
                speedTimer = duration;
            }
            else
                speedTimer += duration;
            //GameObject.Find("HUD").transform.Find("Effects").transform.Find("Text").GetComponent<Text>().text = "speed";
            //GameObject.Find("HUD").transform.Find("Effects").transform.Find("Text").GetComponent<Text>().enabled = false;
            InventorySlotScript.RemoveHotBarItem();
        }
    }

    void Fish()
    {
        FishingScript.currentFishingRod = (FishingRodsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).name);
        Collider2D[] waterColliders = Physics2D.OverlapCircleAll(attackPoint.position, 2f, waterLayer);
        try
        {
            if (waterColliders[0] != null)
            {
                GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().StartFishing(/*waterColliders[0].gameObject*/);
                //GameObject.Find("")
            }
        }

        catch (NullReferenceException e)
        {

        }
    }

    IEnumerator Die()
    {
        if (StartUpScreenButtonsScript.singlePlayerBool)
        {
            //Time.timeScale = 0;
            SpawnPlayers.MYPLAYER.GetComponent<Animator>().enabled = false;
            SpawnPlayers.MYPLAYER.transform.Find("Character Hand").GetComponent<SpriteRenderer>().enabled = false;
            SpawnPlayers.MYPLAYER.GetComponent<SpriteRenderer>().sprite = CharacterController.GetCharacterDead(CharacterController.CurrentCharacter);
            yield return new WaitForSeconds(2);
            //Time.timeScale = 0.02f;
            currentHealth = maxHealth;
            playerHealthBar.SetHealth(currentHealth);
            playerHealthBar.SetHealthText(currentHealth, maxHealth);
            SpawnPlayers.MYPLAYER.GetComponent<Animator>().enabled = true;
            SpawnPlayers.MYPLAYER.transform.position = Vector3.zero;
        }
        else
        {
            Destroy(SpawnPlayers.MYPLAYER);
            Time.timeScale = 0;
        }
        // pause everything for now
    }    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, MeleeWeaponsList.Find(v => v.name == PlayerInventoryControllerScript.nameOfHeldItem).range);
    }
}
