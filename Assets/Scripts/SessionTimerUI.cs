using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText = null;

    private void OnEnable()
    {
        SessionTimer.onTimeUpdate += UpdateText;
    }

    private void OnDisable()
    {
        SessionTimer.onTimeUpdate -= UpdateText;
    }

    private void UpdateText(float time)
    {
        timerText.text = "Timer: " + ((int)time).ToString();
    }
}
