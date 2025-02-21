using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthorb;
    private int health;
    private SceneController sceneController;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void SetHealth(int wave)
    {
        health = wave;
    }

    public void EnemyHurt(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);
        Debug.Log("Enemy Health: " + health);
        if (health <= 0)
        {
            sceneController.EnemyDied(gameObject);
            SpawnHealthOrb();
            Destroy(gameObject);
        }
    }

    private void SpawnHealthOrb()
    {
        GameObject bluehealthorb = Instantiate(healthorb, transform.position, Quaternion.identity);
        Destroy(bluehealthorb, 5f);
    }
}
