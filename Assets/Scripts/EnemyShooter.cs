using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform firingOrigin = null;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float firingInterval = 2f;
    [SerializeField] private float firingProximity = 5f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private GameObject player = null;

    private AudioSource audio;

    private bool playerInRange = false;
    private float firingTimer;

    public static Action onEnemyKilled;

    private void Start()
    {
        firingTimer = firingInterval;
        audio = GetComponent<AudioSource>();
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

    public void SetPlayer(GameObject p)
    {
        player = p;
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
        audio.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            onEnemyKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}
