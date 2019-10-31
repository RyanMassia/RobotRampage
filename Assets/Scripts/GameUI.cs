using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Sprite redReticle;
    [SerializeField] Sprite yellowReticle;
    [SerializeField] Sprite blueReticle;
    [SerializeField] Image reticle;

    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle; // if pistol out aims is red 
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle; //if shotgun out aim is yellow 
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle; // if shotgun out aim is blue
                break;
            default:
              return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
