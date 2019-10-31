using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;//speed gun fires
    protected float lastFireTime;//last time gun fired
    public Ammo ammo;
    public AudioClip liveFire; //sound for when gun fires
    public AudioClip dryFire; // sound for when out of ammo


    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected void Fire()
    {
        if (ammo.HasAmmo(tag)) // if gun has ammo will play fire sound 
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire); ammo.ConsumeAmmo(tag);
        }
        else // if out of ammo will play empty sound
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }

        GetComponentInChildren<Animator>().Play("Fire"); // looks for the animator controller for pistol and plays fire animation
    }
}
