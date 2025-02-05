using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    
    private Rigidbody2D _rb;      
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(transform.right * horizontalSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(transform.up * verticalSpeed);
        }
    }
}
