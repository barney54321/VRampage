using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform firingOrigin = null;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float firingInterval = 2f;
    [SerializeField] private bool playerInRange = false;

    private float firingTimer;

    private void Start()
    {
        firingTimer = firingInterval;
    }

    private void Update()
    {
        if (!playerInRange) { return; }

        firingTimer -= Time.deltaTime;
        if (firingTimer <= 0f)
        {
            // fire
            firingTimer = firingInterval;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firingOrigin);
        
    }
}
