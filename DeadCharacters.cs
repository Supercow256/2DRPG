using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCharacters : MonoBehaviour
{
    // dead sprites
    public Sprite SteveDeadUpSprite_OG;
    public Sprite DianaDeadUpSprite_OG;
    public Sprite SteveDeadDownSprite_OG;
    public Sprite DianaDeadDownSprite_OG;
    public Sprite BoopDeadSprite_OG;
    public Sprite EggDeadUpSprite_OG;
    public Sprite EggDeadDownSprite_OG;
    public Sprite GhostyDeadSprite_OG;
    public Sprite SkellyDeadSprite_OG;

    public static Sprite SteveDeadUpSprite;
    public static Sprite DianaDeadUpSprite;
    public static Sprite SteveDeadDownSprite;
    public static Sprite DianaDeadDownSprite;
    public static Sprite BoopDeadSprite;
    public static Sprite EggDeadUpSprite;
    public static Sprite EggDeadDownSprite;
    public static Sprite GhostyDeadSprite;
    public static Sprite SkellyDeadSprite;
    // dead sprites

    // Start is called before the first frame update
    void Start()
    {
        SteveDeadUpSprite = SteveDeadUpSprite_OG;
        DianaDeadUpSprite = DianaDeadUpSprite_OG;
        SteveDeadDownSprite = SteveDeadDownSprite_OG;
        DianaDeadDownSprite = DianaDeadDownSprite_OG;
        BoopDeadSprite = BoopDeadSprite_OG;
        EggDeadUpSprite = EggDeadUpSprite_OG;
        EggDeadDownSprite = EggDeadDownSprite_OG;
        GhostyDeadSprite = GhostyDeadSprite_OG;
        SkellyDeadSprite = SkellyDeadSprite_OG;
}
}
