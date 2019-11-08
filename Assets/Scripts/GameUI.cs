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
    [SerializeField] private Text ammoText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text armorText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text pickupText;
    [SerializeField] private Text waveText;
    [SerializeField] private Text enemyText;
    [SerializeField] private Text waveClearText;
    [SerializeField] private Text newWaveText;
    [SerializeField] Player player;

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


    //start player and ammo text 
    void Start()
    {
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }
    
    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    } 
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }
    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    // 1 Show the wave clear bonus text
    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    // 2 hide text after 4 seconds
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }
    // 3 sets the pick up text 
    public void SetPickUpText(string text)
    {   pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        // Restart the Coroutine so it doesn’t end early   
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }
    // 4  wait 4 seconds to remove pickup text 
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }
    // 5 new wave tex
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    // 6 wait 4 seconds to remove new wage text
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
