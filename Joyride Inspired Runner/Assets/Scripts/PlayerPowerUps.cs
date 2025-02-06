using System;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    [HideInInspector] public bool shielded;
    [HideInInspector] public bool armed;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && armed)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = firePoint.right * bulletSpeed * _playerMovement.rb.linearVelocity;
            armed = false;
            Debug.Log(armed);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(shielded || armed) return;
        if (other.gameObject.CompareTag("Shield"))
        {
            shielded = true;
            // Debug.Log("Shielded");
        }
        else if (other.gameObject.CompareTag("Gun"))
        {
            armed = true;
        }
    }
}
