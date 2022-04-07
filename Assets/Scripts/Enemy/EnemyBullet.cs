using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private PlayerMovement playerScript;
    private Vector2 targetPosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        targetPosition = playerScript.transform.position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
