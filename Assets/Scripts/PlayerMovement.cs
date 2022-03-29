using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveVelocity;
    public int health;
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private Animator animator;
    public GameObject DeathPrefab;
    public GameManager instance;
    void Start()
    {
        if (this.gameObject != null)
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
       if(health <= 0)
        {
            
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 0f);
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 0f);
            /* animator.SetTrigger("isWalking");*/
            animator.SetBool("isWalking", true);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0f);
            animator.SetBool("isWalking", false);
        }
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            instance.GameOver();
            Instantiate(DeathPrefab, transform.position, Quaternion.identity);
            
        }
    }
    public void ChangeWeapon(weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position + new Vector3(0,1,0), transform.rotation, transform);
        weaponToEquip.gameObject.GetComponent<weapon>().enabled = true;
    }
    void UpdateHealthUI(int currentHealth)
    {

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < currentHealth)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
                hearts[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                hearts[i].GetComponent<Image>().enabled = false;
            }

        }

    }
    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

}
