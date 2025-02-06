using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6f);
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        PlayerPowerUps player = obj.GetComponent<PlayerPowerUps>();
        if (obj.CompareTag("Player") && !player.shielded)
        {
            SceneManager.LoadScene("Adrian Testing");
            // Debug.Log("Player " + obj.name + " is dead");
        }
        else if (obj.CompareTag("Player") && player.shielded)
        {
            player.shielded = false;
            Destroy(gameObject);
            // Debug.Log("Player " + obj.name + " is shielded");
        }
    }
}
