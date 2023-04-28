using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private float spawnInterval = 2.5f;
    [SerializeField] private GameObject player = null;

    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // spawn
            GameObject enemyInstance = Instantiate(enemyPrefab, transform);
            enemyInstance.GetComponent<EnemyMovement>().SetPlayer(player);
            enemyInstance.GetComponent<EnemyShooter>().SetPlayer(player);
            timer = spawnInterval;
        }

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
