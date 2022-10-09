using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //public GameObject EnemyParent;
    [Header ("Enemy Settings")]

    [SerializeField] GameObject Enemy1;
    [SerializeField] int Enemy1Level;
    [SerializeField] int offSetX1;
    [SerializeField] int offSetY1;

    [SerializeField] GameObject Enemy2;
    [SerializeField] int Enemy2Level;
    [SerializeField] int offSetX2;
    [SerializeField] int offSetY2;

    [SerializeField] GameObject Enemy3;
    [SerializeField] int Enemy3Level;
    [SerializeField] int offSetX3;
    [SerializeField] int offSetY3;

    [SerializeField] GameObject Enemy4;
    [SerializeField] int Enemy4Level;
    [SerializeField] int offSetX4;
    [SerializeField] int offSetY4;

    [SerializeField] GameObject Enemy5;
    [SerializeField] int Enemy5Level;
    [SerializeField] int offSetX5;
    [SerializeField] int offSetY5;

    public bool spawn = true;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(SpawnPlayers.MYPLAYER.transform.position, transform.position) <= 3.0f && spawn)
        {
            
            //Debug.Log("You are close");
            GameObject temp;
            
            //GameObject temp1;
            /*
            for (int i = -6; i <=-1; i++)
            {
                temp = Instantiate(_BlueSlime, new Vector3(transform.position.x + i, transform.position.y + i, transform.position.z), Quaternion.identity);
                //temp = Instantiate(_RedSlime, new Vector3(transform.position.x+i, transform.position.y+i, transform.position.z), Quaternion.identity);
                temp.GetComponent<EnemyScript>().level = i+6; 
            }
            */

            temp = Instantiate(Enemy1, new Vector3(transform.position.x + offSetX1, transform.position.y + offSetY1 , transform.position.z), Quaternion.identity);
            temp.GetComponent<EnemyScript>().level = Enemy1Level;
            temp = Instantiate(Enemy2, new Vector3(transform.position.x + offSetX2, transform.position.y + offSetY2, transform.position.z), Quaternion.identity);
            temp.GetComponent<EnemyScript>().level = Enemy2Level;
            temp = Instantiate(Enemy3, new Vector3(transform.position.x + offSetX3, transform.position.y + offSetY3, transform.position.z), Quaternion.identity);
            temp.GetComponent<EnemyScript>().level = Enemy3Level;
            temp = Instantiate(Enemy4, new Vector3(transform.position.x + offSetX4, transform.position.y + offSetY4, transform.position.z), Quaternion.identity);
            temp.GetComponent<EnemyScript>().level = Enemy4Level;
            temp = Instantiate(Enemy5, new Vector3(transform.position.x + offSetX5, transform.position.y + offSetY5, transform.position.z), Quaternion.identity);
            temp.GetComponent<EnemyScript>().level = Enemy5Level;

            spawn = false;
        }
    }
    /*
    IEnumerator SpawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
    }
    */
}
