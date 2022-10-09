using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour
{
    public static GameObject _scitherSword;
    public static List<MeleeWeapon> MeleeWeaponsList = new List<MeleeWeapon>();
    public static List<Throwable> ThrowableWeaponsList = new List<Throwable>();
    public static List<Consumable> ConsumableList = new List<Consumable>();
    public static List<FishingRod> FishingRodsList = new List<FishingRod>();
    public static List<Fish> FishList = new List<Fish>();
    public static List<Armor> ArmorList = new List<Armor>();
    public static List<Pet> PetsList = new List<Pet>();

    public class MeleeWeapon
    {
        public string name { get; set; }
        public string preFabPath { get; set; }
        //public string path;
        public float range { get; set; }
        public int baseDamage { get; set; }
        public double durability { get; set; }
        public string damageType { get; set; }
        public double coolDown { get; set; }
        public int knockbackPower { get; set; }
        public int cost { get; set; }
    };

    public class Throwable
    {
        public string name { get; set; }
        public string preFabPath { get; set; }
        //public string path;
        public float range { get; set; }
        public int baseDamage { get; set; }
        public double durability { get; set; }
        public string damageType { get; set; }
        public double coolDown { get; set; }
        public int knockbackPower { get; set; }
        public int cost { get; set; }
    };

    public class Consumable
    {
        public string name { get; set; }
        //public static GameObject preFab;
        public string effect { get; set; }
        public int strength { get; set; }
        public int duration { get; set; }
        public int cost { get; set; }
    };

    public class FishingRod {
        public string name { get; set; }
        public float hookPower { get; set; }
        public float hookSize { get; set; }
        public float progressBarDecayValue { get; set; }
        public double durability { get; set; }
        public int cost { get; set; }
    };

    public class Fish {
        public string name { get; set; }
        public double rarity { get; set; }
        public double satiety { get; set; }
        public int XP { get; set; }
        public float timeBeforeRotten { get; set; }
        public float fishTimeRandomizer { get; set; }
        public int cost { get; set; }
    };

    public class Armor { 
        public string name { get; set; }
        public string type { get; set; }
        public double strength { get; set; }
        public double durability { get; set; }
        public int cost { get; set; }
    };

    public class Pet
    {
        public string name { get; set; }
        public int baseMaxHealth { get; set; }
        public bool isHostile { get; set; }
        public double baseAttack { get; set; }
        public double textPos { get; set; }
        public int cost { get; set; }
    };

    void Start()
    {
        DeclareMeleeWeapons();
        DeclareConsumables();
        DeclareFishingRods();
        DeclareFish();
        DeclareArmor();
        DeclarePets();
    }
        
    void DeclareMeleeWeapons()
    {
        // Weapons
        MeleeWeapon Sword_1 = new MeleeWeapon();
        Sword_1.name = "Sword_1";
        Sword_1.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_1.prefab";
        Sword_1.range = 0.5f;
        Sword_1.baseDamage = 2;
        Sword_1.durability = 95.0;
        Sword_1.damageType = "Bludgeon";
        Sword_1.coolDown = 1.5;
        Sword_1.knockbackPower = 1;
        Sword_1.cost = 25;
        MeleeWeaponsList.Add(Sword_1);

        MeleeWeapon Sword_2 = new MeleeWeapon();
        Sword_2.name = "Sword_2";
        Sword_2.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_2.prefab";
        Sword_2.range = 1f;
        Sword_2.baseDamage = 3;
        Sword_2.durability = 95.0;
        Sword_2.damageType = "Bludgeon";
        Sword_2.coolDown = 1.5;
        Sword_2.knockbackPower = 1;
        Sword_2.cost = 80;
        MeleeWeaponsList.Add(Sword_2);

        MeleeWeapon Sword_3 = new MeleeWeapon();
        Sword_3.name = "Sword_3";
        Sword_3.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_3.prefab";
        Sword_3.range = 1f;
        Sword_3.baseDamage = 4;
        Sword_3.durability = 95.0;
        Sword_3.damageType = "Bludgeon";
        Sword_3.coolDown = 1.5;
        Sword_3.knockbackPower = 2;
        Sword_3.cost = 110;
        MeleeWeaponsList.Add(Sword_3);

        MeleeWeapon Sword_4 = new MeleeWeapon();
        Sword_4.name = "Sword_4";
        Sword_4.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_4.prefab";
        Sword_4.range = 1.5f;
        Sword_4.baseDamage = 5;
        Sword_4.durability = 95.0;
        Sword_4.damageType = "Bludgeon";
        Sword_4.coolDown = 1.5;
        Sword_4.knockbackPower = 2;
        Sword_4.cost = 150;
        MeleeWeaponsList.Add(Sword_4);

        MeleeWeapon Sword_5 = new MeleeWeapon();
        Sword_5.name = "Sword_5";
        Sword_5.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_5.prefab";
        Sword_5.range = 1f;
        Sword_5.baseDamage = 6;
        Sword_5.durability = 95.0;
        Sword_5.damageType = "Bludgeon";
        Sword_5.coolDown = 1.5;
        Sword_5.knockbackPower = 2;
        Sword_5.cost = 190;
        MeleeWeaponsList.Add(Sword_5);

        MeleeWeapon Sword_6 = new MeleeWeapon();
        Sword_6.name = "Sword_6";
        Sword_6.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_6.prefab";
        Sword_6.range = 1.5f;
        Sword_6.baseDamage = 7;
        Sword_6.durability = 95.0;
        Sword_6.damageType = "Bludgeon";
        Sword_6.coolDown = 1.5;
        Sword_6.knockbackPower = 2;
        Sword_6.cost = 240;
        MeleeWeaponsList.Add(Sword_6);

        MeleeWeapon Sword_7 = new MeleeWeapon();
        Sword_7.name = "Sword_7";
        Sword_7.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_7.prefab";
        Sword_7.range = 1f;
        Sword_7.baseDamage = 8;
        Sword_7.durability = 95.0;
        Sword_7.damageType = "Bludgeon";
        Sword_7.coolDown = 1.5;
        Sword_7.knockbackPower = 2;
        Sword_7.cost = 290;
        MeleeWeaponsList.Add(Sword_7);

        MeleeWeapon Sword_8 = new MeleeWeapon();
        Sword_8.name = "Sword_8";
        Sword_8.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_8.prefab";
        Sword_8.range = 1.5f;
        Sword_8.baseDamage = 8;
        Sword_8.durability = 95.0;
        Sword_8.damageType = "Bludgeon";
        Sword_8.coolDown = 1.5;
        Sword_8.knockbackPower = 3;
        Sword_8.cost = 375;
        MeleeWeaponsList.Add(Sword_8);

        MeleeWeapon Sword_9 = new MeleeWeapon();
        Sword_9.name = "Sword_9";
        Sword_9.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_9.prefab";
        Sword_9.range = 1.5f;
        Sword_9.baseDamage = 9;
        Sword_9.durability = 95.0;
        Sword_9.damageType = "Bludgeon";
        Sword_9.coolDown = 1.5;
        Sword_9.knockbackPower = 3;
        Sword_9.cost = 460;
        MeleeWeaponsList.Add(Sword_9);

        MeleeWeapon scitherSword = new MeleeWeapon();
        scitherSword.name = "scitherSword";
        scitherSword.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Scither Sword/scithersword.prefab";
        scitherSword.range = 1.5f;
        scitherSword.baseDamage = 10;
        scitherSword.durability = 95.0;
        scitherSword.damageType = "Bludgeon";
        scitherSword.coolDown = 1.5;
        scitherSword.knockbackPower = 4;
        scitherSword.cost = 650;
        MeleeWeaponsList.Add(scitherSword);
    }

    void DeclareThrowableWeapons()
    {
        Throwable Boomerang = new Throwable();
        Boomerang.name = "Sword_1";
        //Boomerang.preFabPath = "Assets/Items/Tools/Weapons/Melee/Swords/Sword_1.prefab";
        Boomerang.range = 6.0f;
        Boomerang.baseDamage = 4;
        Boomerang.durability = 95.0;
        Boomerang.damageType = "Bludgeon";
        Boomerang.coolDown = 1.5;
        Boomerang.knockbackPower = 1;
        Boomerang.cost = 85;
        ThrowableWeaponsList.Add(Boomerang);
    }

    void DeclareConsumables()
    {
        Consumable Potion_5 = new Consumable();
        Potion_5.name = "Potion_5";
        Potion_5.effect = "Heal";
        Potion_5.strength = 100;
        Potion_5.duration = 1;
        Potion_5.cost = 50;
        ConsumableList.Add(Potion_5);

        Consumable Potion_8 = new Consumable();
        Potion_8.name = "Potion_8";
        Potion_8.effect = "Speed";
        Potion_8.strength = 9;
        Potion_8.duration = 30;
        Potion_8.cost = 75;
        ConsumableList.Add(Potion_8);
    }

    void DeclareFishingRods()
    {
        /*
         * hook power is set to 0.4
         * 
         * DO NOT CHANGE YET
         * hook size is set to 0.12
         * DO NOT CHANGE YET
         * 
         * progressBarDecayValue is set to 0.1
         * 
         * */
        FishingRod Starter_Rod = new FishingRod();
        Starter_Rod.name = "Starter_Rod";
        Starter_Rod.hookPower = 0.3f;
        //Starter_Rod.hookSize = 0.12f;
        Starter_Rod.progressBarDecayValue = 0.2f;
        Starter_Rod.durability = 80.0;
        Starter_Rod.cost = 50;
        FishingRodsList.Add(Starter_Rod);


        FishingRod FishingRod_1 = new FishingRod();
        FishingRod_1.name = "FishingRod_1";
        FishingRod_1.hookPower = 0.7f;
        //Starter_Rod.hookSize = 0.12f;
        FishingRod_1.progressBarDecayValue = 0.2f;
        FishingRod_1.durability = 80.0;
        FishingRod_1.cost = 100;
        FishingRodsList.Add(FishingRod_1);

        FishingRod FishingRod_2 = new FishingRod();
        FishingRod_2.name = "FishingRod_2";
        FishingRod_2.hookPower = 0.3f;
        //Starter_Rod.hookSize = 0.12f;
        FishingRod_2.progressBarDecayValue = 0.2f;
        FishingRod_2.durability = 80.0;
        FishingRod_2.cost = 150;
        FishingRodsList.Add(FishingRod_2);
    }
    
    void DeclareFish()
    {
        Fish Carp = new Fish();
        Carp.name = "Carp";
        Carp.rarity = 30.0;
        Carp.satiety = 50.0;
        Carp.XP = 10;
        Carp.timeBeforeRotten = 300.0f;
        Carp.fishTimeRandomizer = 3f;
        Carp.cost = 75;
        FishList.Add(Carp);

        Fish Frog = new Fish();
        Frog.name = "Frog";
        Frog.rarity = 25.5;
        Frog.satiety = 50.0;
        Frog.XP = 15;
        Frog.timeBeforeRotten = 300.0f;
        Frog.fishTimeRandomizer = 3f;
        Frog.cost = 85;
        FishList.Add(Frog);

        Fish PufferFish = new Fish();
        PufferFish.name = "PufferFish";
        PufferFish.rarity = 20.0;
        PufferFish.satiety = 50.0;
        PufferFish.XP = 20;
        PufferFish.timeBeforeRotten = 300.0f;
        PufferFish.fishTimeRandomizer = 3.5f;
        PufferFish.cost = 120;
        FishList.Add(PufferFish);

        Fish SeaHorse = new Fish();
        SeaHorse.name = "SeaHorse";
        SeaHorse.rarity = 10.5;
        SeaHorse.satiety = 50.0;
        SeaHorse.XP = 30;
        SeaHorse.timeBeforeRotten = 300.0f;
        SeaHorse.fishTimeRandomizer = 4f;
        SeaHorse.cost = 210;
        FishList.Add(SeaHorse);

        Fish Squid = new Fish();
        Squid.name = "Squid";
        Squid.rarity = 9.5;
        Squid.satiety = 50.0;
        Squid.XP = 32;
        Squid.timeBeforeRotten = 300.0f;
        Squid.fishTimeRandomizer = 3.5f;
        Squid.cost = 225;
        FishList.Add(Squid);

        Fish StarFish = new Fish();
        StarFish.name = "StarFish";
        StarFish.rarity = 12.5;
        StarFish.satiety = 50.0;
        StarFish.XP = 26;
        StarFish.timeBeforeRotten = 300.0f;
        StarFish.fishTimeRandomizer = 4f;
        StarFish.cost = 195;
        FishList.Add(StarFish);

        Fish DeadFish = new Fish();
        DeadFish.name = "DeadFish";
        DeadFish.rarity = 10.0;
        DeadFish.satiety = 50.0;
        DeadFish.XP = 5;
        DeadFish.timeBeforeRotten = 300.0f;
        DeadFish.fishTimeRandomizer = 3f;
        DeadFish.cost = 25;
        FishList.Add(DeadFish);
        
    }

    void DeclareArmor()
    {
        Armor ChestPlate = new Armor();
        ChestPlate.name = "ChestPlate";
        ChestPlate.type = null;
        //ChestPlate.strength = 
        ChestPlate.durability = 120.0;
        ChestPlate.cost = 80;
        ArmorList.Add(ChestPlate);
    }

    void DeclarePets()
    {
        Pet Red_Slime = new Pet();
        Red_Slime.name = "Red_Slime";
        Red_Slime.baseMaxHealth = 50;
        Red_Slime.isHostile = false;
        Red_Slime.baseAttack = 2;
        Red_Slime.textPos = 0;
        Red_Slime.cost = 80;
        PetsList.Add(Red_Slime);

        Pet Green_Slime = new Pet();
        Green_Slime.name = "Green_Slime";
        Green_Slime.baseMaxHealth = 50;
        Green_Slime.isHostile = false;
        Green_Slime.baseAttack = 2;
        Green_Slime.textPos = 0;
        Green_Slime.cost = 80;
        PetsList.Add(Green_Slime);

        Pet Blue_Slime = new Pet();
        Blue_Slime.name = "Blue_Slime";
        Blue_Slime.baseMaxHealth = 50;
        Blue_Slime.isHostile = false;
        Blue_Slime.baseAttack = 2;
        Blue_Slime.textPos = 0;
        Blue_Slime.cost = 80;
        PetsList.Add(Blue_Slime);

        Pet Orange_Slime = new Pet();
        Orange_Slime.name = "Orange_Slime";
        Orange_Slime.baseMaxHealth = 50;
        Orange_Slime.isHostile = false;
        Orange_Slime.baseAttack = 2;
        Orange_Slime.textPos = 0;
        Orange_Slime.cost = 80;
        PetsList.Add(Orange_Slime);

        Pet Shroomy = new Pet();
        Shroomy.name = "Shroomy";
        Shroomy.baseMaxHealth = 80;
        Shroomy.isHostile = false;
        Shroomy.baseAttack = 3;
        Shroomy.textPos = 0.3;
        Shroomy.cost = 120;
        PetsList.Add(Shroomy);
    }
}

