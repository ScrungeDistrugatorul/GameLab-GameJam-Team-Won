using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float boost;
    public float acceleration;
    
    [HideInInspector] public Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * boost, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.right * horizontalSpeed * Time.fixedDeltaTime * acceleration);
        Debug.Log(rb.linearVelocity.x);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * verticalSpeed);
        }
    }
}
