using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        PlayerPowerUps player = obj.GetComponent<PlayerPowerUps>();
        if (obj.CompareTag("Player") && !player.shielded)
        {
            SceneManager.LoadScene(2);
            // Debug.Log("Player " + obj.name + " is dead");
        }
        else if (obj.CompareTag("Player") && player.shielded)
        {
            player.activeSprite.SetActive(false);
            player.shielded = false;
            Destroy(gameObject);
            // Debug.Log("Player " + obj.name + " is shielded");
        }
    }
}
