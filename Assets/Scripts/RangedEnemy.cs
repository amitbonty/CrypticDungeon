﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemies
{
    public float stopDistance;
    private float attackTime;
    public GameObject enemyBullet;
    public Transform shotPoint;
    public override void Start()
    {
        base.Start();
        InvokeRepeating("RangedAttack", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Debug.Log("Called1");
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }
    public void RangedAttack()
    {

        if (player != null)
        {

            Vector2 direction = player.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);

        }

    }
}
