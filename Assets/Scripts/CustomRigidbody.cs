using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbody : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform planet;
    public float gravity=3;
    bool hasCollided;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        
        //Debug.Log(Mathf.Atan2(transform.position.y,transform.position.x)*Mathf.Rad2Deg+90);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg - 90);
        if(!hasCollided)
        rb.AddForce((planet.position-transform.position).normalized*gravity,ForceMode2D.Force);
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag != "Player")
        {
            if (collision.gameObject.CompareTag("Planet"))
            {
                transform.parent = collision.gameObject.transform;
            }
        }

    }
}