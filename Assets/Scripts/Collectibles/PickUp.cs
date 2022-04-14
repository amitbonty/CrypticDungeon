using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private Weapon weaponToEquip;
    [SerializeField]
    private GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (transform.parent.gameObject.CompareTag("Player"))
        { 
            this.gameObject.GetComponent<Weapon>().enabled = true; 
        }
        else 
        { 
            this.gameObject.GetComponent<Weapon>().enabled = false; 
        }
    }

}
