using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform firingOrigin = null;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float firingInterval = 2f;
    [SerializeField] private float firingProximity = 5f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private GameObject player = null;

    private bool playerInRange = false;
    private float firingTimer;

    private void Start()
    {
        firingTimer = firingInterval;
    }

    private void Update()
    {
        CheckIfPlayerInRange();
        if (!playerInRange) { return; }

        firingTimer -= Time.deltaTime;
        if (firingTimer <= 0f)
        {
            // fire
            firingTimer = firingInterval;
            Fire();
        }
    }

    private void CheckIfPlayerInRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= firingProximity)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firingOrigin);
        projectile.transform.LookAt(player.transform, Vector3.up);
        Vector3 dir = player.transform.position - projectile.transform.position;
        projectile.GetComponent<Rigidbody>().AddForce(dir * projectileSpeed);
    }
}
