using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveVelocity;
    private Animator animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
    [SerializeField]
    private GameObject DeathPrefab;
    void Start()
    {
        if (this.gameObject != null)
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
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
            GameManager.Instance.GameOver();
            Instantiate(DeathPrefab, transform.position, Quaternion.identity);
        }
    }
    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position + new Vector3(0,1,0), transform.rotation, transform);
        weaponToEquip.gameObject.GetComponent<Weapon>().enabled = true;
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
