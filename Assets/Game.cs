using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private static Game singleton;
    [SerializeField]RobotSpawn[] spawns; // array of spawns
    public int enemiesLeft; // tells how many enemies left 
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;

    // Start is called before the first frame update
    // 1 sets singleton so only 1 instance of game can exist, then calls spawn robots
    void Start()
    {
        singleton = this;
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false; Time.timeScale = 1;
        waveCountdown = 30; enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
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
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);
            // Spawn next wave and restart count down  
            if (waveCountdown == 0)
            {       SpawnRobots();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        // Give player bonus for clearing the wave before timer is done   
        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
