using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    Animator an;
    Rigidbody2D rb;
    public bool gameStarted;
    bool isGrounded;
    public LayerMask groundMask;
    float InitialGravity;
    [SerializeField] CustomRigidbody dinoRb;
    private void Awake()
    {
        InitialGravity = dinoRb.gravity;
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isGrounded)
        {
            an.SetInteger("State", 3);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                an.SetInteger("State", 1);
                rb.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                an.SetInteger("State", 3);
                rb.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
                an.SetInteger("State", 2);
            else if (GameManager.Instance.GameStarted && isGrounded)
            {
                an.SetInteger("State", 1);
            }
        }
            
        isGrounded = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.35f, groundMask);
        dinoRb.gravity = isGrounded ? InitialGravity : InitialGravity * 2f;
    }

    
}
