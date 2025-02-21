using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private bool playerShooter = false;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private bool collided = false;
    private void OnTriggerEnter(Collider other)
    {
        if (collided) 
        {
            return;
        }
        if (playerShooter)
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.EnemyHurt(damage);
            }
        }
        else
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
            collided = true;
        }
        }
        

        Destroy(this.gameObject);
    }

    public void GunHolder(bool gunnerholder)
    {
        playerShooter = gunnerholder;
    }
}
