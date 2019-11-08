using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    // Start is called before the first frame update
    void spawnPickup()
    {   // Instantiate a random pickup   
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    // 2 wait 20 seconds before fall the respawn 
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }

    // 3 spawns pickup as soon as game begins
    void Start()
    {
        spawnPickup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 4 sstarts coroutine  to respawn when player picks up something
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup");
    } 



}