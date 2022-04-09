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
    [SerializeField]
    Rigidbody2D rb;
    void Start()
    {
        playerScript = PlayerMovement.Instance;
        targetPosition = playerScript.transform.position;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
