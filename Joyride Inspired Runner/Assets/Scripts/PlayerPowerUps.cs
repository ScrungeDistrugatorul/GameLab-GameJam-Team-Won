using System;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject[] playerStates;
    public AudioSource pickUpSound;
    public AudioClip[] sounds;
    
    [HideInInspector] public bool shielded;
    [HideInInspector] public bool armed;
    [HideInInspector] public GameObject activeSprite;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        activeSprite = playerStates[0];
        activeSprite.SetActive(false);
        pickUpSound.volume = 0.4f;
    }


    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z)) && armed)
        {
            pickUpSound.PlayOneShot(sounds[1]);
            activeSprite.SetActive(false);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = firePoint.right * bulletSpeed * _playerMovement.rb.linearVelocity;
            armed = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(shielded || armed) return;
        if (other.gameObject.CompareTag("Shield"))
        {
            shielded = true;
            foreach (var state in playerStates)
            {
                if (state == playerStates[1])
                {
                    activeSprite.SetActive(false);
                    activeSprite = state;
                    activeSprite.SetActive(true);
                }
            }
            pickUpSound.PlayOneShot(sounds[0]);

            // Debug.Log("Shielded");
        }
        else if (other.gameObject.CompareTag("Gun"))
        {
            armed = true;
            foreach (var state in playerStates)
            {
                if (state == playerStates[0])
                {
                    activeSprite.SetActive(false);
                    activeSprite = state;
                    activeSprite.SetActive(true);
                }
            }
            pickUpSound.PlayOneShot(sounds[0]);
        }
    }
}
