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

    public float zoomFactor; // level of zoom
    public int range;//range of weapon
    public int damage; //damage of weapon 
    private float zoomFOV; //field of view zoomed in
    private float zoomSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Right Click (Zoom)   
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);   }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;

        }
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

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            processHit(hit.collider.gameObject);
        }
    }

    private void processHit(GameObject hitObject)
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }
}
