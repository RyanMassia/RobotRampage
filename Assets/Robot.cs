using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
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
            fire();
        }
    }

    private void fire()
    {
        robot.Play("Fire");
    }
}