using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int health;
    [HideInInspector]
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public int healthPickupChance;
    public GameObject healthPickup;

    public GameObject deathEffect;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            GameManager.score += 5;
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                Debug.Log(Random.Range(0, pickups.Length));
                GameObject randomPickup = pickups[/*Random.Range(0, pickups.Length)*/1];

                Instantiate(randomPickup, transform.position, transform.rotation);
            }

            int randHealth = Random.Range(0, 101);
            if (randHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
  

}
