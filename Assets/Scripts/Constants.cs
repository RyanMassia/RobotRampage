using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{   // Scenes   
    public const string SceneBattle = "Battle";  //battle scence
    public const string SceneMenu = "MainMenu"; // main menu scence
    // Gun Types   
    public const string Pistol = "Pistol"; //pistal gameobject name 
    public const string Shotgun = "Shotgun"; //shotguin gamobject name
    public const string AssaultRifle = "AssaultRifle"; //assualt rifle gameobject name 
    // Robot Types   
    public const string RedRobot = "RedRobot"; //redbot gameobject name 
    public const string BlueRobot = "BlueRobot"; //bluebot gameobject name 
    public const string YellowRobot = "YellowRobot"; //yellow gameobject name 
    // Pickup Types   
    public const int PickUpPistolAmmo = 1; // pistol ammo gameobject name 
    public const int PickUpAssaultRifleAmmo = 2; // assault rifle ammo gameobject name 
    public const int PickUpShotgunAmmo = 3; //shotgun ammo gameobject name 
    public const int PickUpHealth = 4; //pick up health gameobject name 
    public const int PickUpArmor = 5;// pick up armor gameobject name 
    // Misc   
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;
    // keeps track  of pick ups
    public static readonly int[] AllPickupTypes = new int[5] 
    {
      PickUpPistolAmmo,
      PickUpAssaultRifleAmmo,
      PickUpShotgunAmmo,
      PickUpHealth,
      PickUpArmor
    };
}
