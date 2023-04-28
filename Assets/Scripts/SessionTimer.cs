using System.Collections;
using UnityEngine;
using System;

public class SessionTimer : MonoBehaviour
{
    [SerializeField] private float sessionTime = 30f;

    private float timeRemaining;

    public static Action<float> onTimeUpdate;
    public static Action onFinish;

    private void Start()
    {
        timeRemaining = sessionTime;
        onTimeUpdate?.Invoke(timeRemaining);
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0f)
        {
            Debug.Log("YOU WON!");
            onFinish?.Invoke();
        }

        onTimeUpdate?.Invoke(timeRemaining);
    }
}