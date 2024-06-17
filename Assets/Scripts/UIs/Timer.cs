using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timeText;

    float leftTime;
    float limitTime = 60f;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.monster.monsterHelthSystem.OnDeath += ResetTime;
        leftTime = limitTime;
    }

    private void Update()
    {
        leftTime -= Time.deltaTime;
        timeText.text = leftTime.ToString("F2");
    }

    private void ResetTime()
    {
        leftTime = limitTime;
    }
}
