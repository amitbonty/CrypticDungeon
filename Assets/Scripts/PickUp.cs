using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public weapon weaponToEquip;

    public GameObject effect;
    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*Instantiate(effect, transform.position, Quaternion.identity);*/
            collision.GetComponent<PlayerMovement>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }
    private void Update()
    {

        if (transform.parent.tag == "Player")
        { this.gameObject.GetComponent<weapon>().enabled = true; }
        else { this.gameObject.GetComponent<weapon>().enabled = false; }
    }

}
