using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    
    protected Transform player;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float timeBetweenAttacks;
    [SerializeField]
    protected int damage;
    [SerializeField]
    private int pickUpChance;
    [SerializeField]
    private GameObject[] pickUps;
    [SerializeField]
    private int healthPickupChance;
    [SerializeField]
    private GameObject healthPickup;
    [SerializeField]
    private GameObject deathEffect;
    public int health;

    public virtual void Start()
    {
        player = PlayerMovement.Instance.transform;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            GameManager.Instance.score += 5;
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickUpChance)
            {
                GameObject randomPickup = pickUps[1];
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
