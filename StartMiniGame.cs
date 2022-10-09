using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
    //[Header]
    //[SerializedField] GameObject FishingGame;
    [Header("Fishing Game")]
    [SerializeField] public static GameObject FishingGame;

    public static void StartFishing()
    {
        Instantiate(FishingGame, SpawnPlayers.MYPLAYER.transform.position, Quaternion.identity);
    }

}
