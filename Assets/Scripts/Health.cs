using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isPlayer = false;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Called by the projectile hitting this game object
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0f, currentHealth - damage);
        if (currentHealth == 0f)
        {
            // die
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            // enemy died
            Destroy(gameObject);
        }
        else
        {
            // player died
            Debug.Log("Player died");
        }
    }
}
