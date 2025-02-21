using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = 25;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health : {health}");
        if (health <= 0)
        {
            Debug.Log("Player has died!!! Game over!");
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<healthorb>() != null)
        {
            health += 2;
            Destroy(other.gameObject);
            Debug.Log("Health gained! Current Health: " + health);
        }
    }
}
