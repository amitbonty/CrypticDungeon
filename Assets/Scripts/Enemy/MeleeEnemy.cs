using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemies {
    [SerializeField]
    private float attackSpeed;
    private float attackTime;
    public bool isInRange;
    private Coroutine attack;
    

    void Update()
    {
        if(player != null&&!isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            isInRange = true;
            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                StartAttackRoutine();
            }
       }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
        isInRange = false;
        }
    }
    IEnumerator Attack()
    {
        player.GetComponent<PlayerMovement>().TakeDamage(damage);
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;
        float percent = 0;
        while(percent <=1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
    void StartAttackRoutine()
    {
       if(attack==null)
       {
        attack=StartCoroutine(Attack());
       }
    } 
}


