using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns; // array of spawns
    public int enemiesLeft; // tells how many enemies left 

    // Start is called before the first frame update
    // 1 sets singleton so only 1 instance of game can exist, then calls spawn robots
    void Start()
    {
        singleton = this;
        SpawnRobots();
    }
    // 2 goes through array and spawns robots
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
