using System.Collections;
using UnityEngine;
using System;

public class SessionTimer : MonoBehaviour
{
    [SerializeField] private float sessionTime = 30f;

    public GameObject win;

    public static bool haveWon = false;

    private float timeRemaining;

    public static Action<float> onTimeUpdate;

    private void Start()
    {
        timeRemaining = sessionTime;
        onTimeUpdate?.Invoke(timeRemaining);
    }

    private void Update()
    {
        if (timeRemaining >= 0f)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0f && PlayerHealthScript.health > 0)
            {
                win.SetActive(true);
                haveWon = true;
                PlayerHealthScript.win = true;
            }

            onTimeUpdate?.Invoke(timeRemaining);
        }
    }
}