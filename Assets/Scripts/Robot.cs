using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip weakHitSound;
    [SerializeField]
    private string robotType; // which type of robot ()
    public int health; // how much damage can take 
    public int range; //how far weapon can fire 
    public float fireRate; // firerate of missles
    public Transform missileFireSpot;
    public Animator robot;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player; //tracks the player 
    private float timeLastFired; // cheaks when gun lasts 
    private bool isDead; // if bool is true robot dead



    // Start is called before the first frame update
    void Start()
    {   // 1   
        isDead = false; // robot isnt dead
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // looks for navmesh agent
        player = GameObject.FindGameObjectWithTag("Player").transform; // looks for object with player tag
    }

    // Update is called once per frame
    void Update()
    {   // 2  
        if (isDead)
        {
            return;
        }
        // 3   
        transform.LookAt(player);
        // 4   
        agent.SetDestination(player.position);
        // 5   
        if (Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastFired > fireRate)
        {     // 6     
            timeLastFired = Time.time;
            Fire();
        }
    }

    private void Fire()
    { GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
        GetComponent<AudioSource>().PlayOneShot(fireSound);
    }

    //1 when player dies play death animation before robot
    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            robot.Play("Die");
            StartCoroutine("DestroyRobot");
            GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(weakHitSound);
        }
    }
    // 2 
    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(1.5f);
        Game.RemoveEnemy();
        Destroy(gameObject);
    } 
}