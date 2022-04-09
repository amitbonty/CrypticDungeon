using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float lifeTime;
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    int damage;
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Enemies>())
        {
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            if(enemy.health <= 0)
            {
                DestroyProjectile();
                Destroy(enemy.gameObject);
            }
            collision.gameObject.GetComponent<Enemies>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
