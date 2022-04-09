using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemies
{
    [SerializeField]
    float minX,maxX,minY,maxY;
    [SerializeField]
    GameObject enemyToSummon;
    private Vector3 targetPosition;
    
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector3(randomX, randomY,0f);
        InvokeRepeating("Summon", 5f, 5f);
    }
    private void Update()
    {
        if(player!=null)
        {
            if (transform.position==targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
