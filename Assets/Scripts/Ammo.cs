using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    [SerializeField] private int pistolAmmo = 20; //tracjs pistol ammo count 
    [SerializeField] private int shotgunAmmo = 10; //tracks shotgun ammo count 
    [SerializeField] private int assaultRifleAmmo = 50; //track assaultRifle ammo count 
    public Dictionary<string, int> tagToAmmo;

    void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
        {
            { Constants.Pistol, pistolAmmo},
            { Constants.Shotgun, shotgunAmmo},
            { Constants.AssaultRifle, assaultRifleAmmo},
        };
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAmmo(string tag, int ammo) 
    {
        if (!tagToAmmo.ContainsKey(tag)) { Debug.LogError("Unrecognized gun type passed: " + tag); } //error if doesnt have correct tag
        tagToAmmo[tag] += ammo;  // adds the ammo to the correct gun type 
    }

    // Returns true if gun has ammo 
    public bool HasAmmo(string tag) //if has ammo is true, if not it says has no more bullets
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        } 

        return tagToAmmo[tag] > 0; 
    }

    public int GetAmmo(string tag) // returns ammo count for that gun
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        return tagToAmmo[tag];
    }

    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        tagToAmmo[tag]--;
        gameUI.SetAmmoText(tagToAmmo[tag]);
    }
}
