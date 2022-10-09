using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] public GameObject FishingGame;

    GameObject temp;
    public bool isOpen;
    void OnMouseDown()
    {
        if (!isOpen)
        {
            temp = Instantiate(FishingGame, new Vector3 (SpawnPlayers.MYPLAYER.transform.position.x - 2.5f , SpawnPlayers.MYPLAYER.transform.position.y - 2.5f, 0f), Quaternion.identity);
            temp.transform.parent = gameObject.transform;
            isOpen = true;
        }
    }
}
