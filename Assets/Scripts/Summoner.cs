using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemies
{
    public float minX,maxX,minY,maxY;
    private Vector2 targetPosition;
    public float timeBetweensummons;
    private float summonTime;
    public GameObject enemyToSummon;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        InvokeRepeating("Summon", 5f, 5f);
    }

 
    private void Update()
    {
        if(player!=null)
        {
            
            if (Vector2.Distance(transform.position, targetPosition) > .05f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                Debug.Log("Called1");
            }
            else
            {
                if(Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweensummons;
                }
            }
        }
        
    }
    public void Summon()
    {
        if(player!= null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }
}
