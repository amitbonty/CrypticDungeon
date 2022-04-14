using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemies
{
    [SerializeField]
    GameObject enemyBullet;
    [SerializeField]
    Transform shotPoint;
    public bool isInRange;
    public override void Start()
    {
        base.Start();
        InvokeRepeating("RangedAttack", 5f, 5f);
    }

    void Update()
    {
        if (player != null && !isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>())
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<Player>())
        {
            isInRange = false;
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
