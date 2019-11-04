using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f; // moves at a speed of 30
    public int damage = 10; // does 10 damage

    // 1 you start a coroutine called deathTimer
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    // 2  moves missle forward at speed * time between frames 
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // 3  10 seconds have passed will resume 
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player") // if players is still actice take damage
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
