using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    public static string activeWeaponType;
    public GameObject pistol; // pistol gameobject
    public GameObject assaultRifle; //assault rifle gameobject
    public GameObject shotgun; //shotgun gameobject
    GameObject activeGun;

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;

    }

    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))  //loads the pistol and equips it
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        if (Input.GetKeyDown("2")) //loads the assault rifle and equips it
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }
        else if(Input.GetKeyDown("3"))//loads the shotgun and equips it
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
    }

    public GameObject GetActiveWeapon()
   {
        return activeGun; //returns the active gun
   }
}
