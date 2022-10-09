using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{

    // make le fish move
    [Header("Fishing Area")]
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottomBounds;

    [Header("Fish Settings")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 3f; // smooth out fish movement
    [SerializeField] float fishTimeRandomizer = 3f; // how often the fish moves
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;
    int fishXP;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = 0.18f;
    [SerializeField] float hookSpeed = 0.1f;
    [SerializeField] float hookGravity = 0.05f;
    float hookPosition;
    float hookPullVelocity;

    [Header("Hook Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecayValue;
    float catchProgress;

    // Fish Prefabs
    [Header("Fish Prefabs")]
    [SerializeField] GameObject Carp;
    [SerializeField] GameObject Frog;
    [SerializeField] GameObject PufferFish;
    [SerializeField] GameObject SeaHorse;
    [SerializeField] GameObject Squid;
    [SerializeField] GameObject StarFish;
    [SerializeField] GameObject DeadFish;
    // Fish Prefabs
    GameObject MyFish;

    double[] FishRarity = new double[7];
    GameObject[] FishPrefabs = new GameObject[7];


    public static string currentFishingRod;

    void Start()
    {
        catchProgress = 0.3f;
        FishPrefabs[0] = Carp; 
        FishPrefabs[1] = Frog; 
        FishPrefabs[2] = PufferFish; 
        FishPrefabs[3] = SeaHorse; 
        FishPrefabs[4] = Squid; 
        FishPrefabs[5] = StarFish; 
        FishPrefabs[6] = DeadFish;
        ResetSpawnWeights();
        SelectRandomFish();
        GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().FreezeAll();
    }

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }

    private void GetFishingRodStats(string fishingRod)
    {
        hookPower = ItemsScript.FishingRodsList.Find(v => v.name == fishingRod).hookPower;
        progressBarDecayValue = ItemsScript.FishingRodsList.Find(v => v.name == fishingRod).progressBarDecayValue;
        hookSize = ItemsScript.FishingRodsList.Find(v => v.name == fishingRod).progressBarDecayValue;
    } 

    private void ResetSpawnWeights()
    {
        double TotalWeight = 0;

        for (int i = 0; i < FishRarity.Length; i++)
        {
            FishRarity[i] = ItemsScript.FishList[i].rarity;
            TotalWeight += FishRarity[i];
        }

        for (int i = 0; i < FishRarity.Length; i++)
        {
            FishRarity[i] = FishRarity[i] / TotalWeight;
        }
    }

    private void SelectRandomFish()
    {
        double Value = Random.value;
            
        for (int i = 0; i <FishRarity.Length; i++)
        {
            if (Value < FishRarity[i])
            {
                fish.GetComponent<SpriteRenderer>().sprite = FishPrefabs[i].GetComponent<SpriteRenderer>().sprite;
                fishTimeRandomizer = ItemsScript.FishList.Find(v => v.name == FishPrefabs[i].name).fishTimeRandomizer;
                fishXP = ItemsScript.FishList.Find(v => v.name == FishPrefabs[i].name).XP;
                Debug.Log("" + FishPrefabs[i].name);
                MyFish = FishPrefabs[i];
                return;
            }
        Value -= FishRarity[i];
        }
    }

    // win and lose are here
    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if (catchProgress >= 1)
            {
                //Debug.Log("YOU WIN!");
                // win logic
                GameHandlerScript.fishingGameIsOpen = false;
                Destroy(this.gameObject);
                Instantiate(MyFish, SpawnPlayers.MYPLAYER.transform.position, Quaternion.identity);
                SpawnPlayers.MYPLAYER.GetComponent<XPScript>().GainXP(fishXP);
                GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().ResumeAll();
            }
        }
        else
        {
            catchProgress -= progressBarDecayValue * Time.deltaTime;
            if (catchProgress <= 0)
            {
                //Debug.Log("YOU LOSE!");
                //lose logic
                // transform.parent.GetComponent<WaterTrigger>().isOpen = false;
                GameHandlerScript.fishingGameIsOpen = false;

                Destroy(this.gameObject);
                GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().ResumeAll();
            }
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }
        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomBounds.position, topBounds.position, hookPosition);
    }

    private void MoveFish()
    {
        // based on timer, pick random POS
        // move fish there smoothly

        fishTimer -= Time.deltaTime;
        if(fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomBounds.position, topBounds.position, fishPosition);
    }


}
