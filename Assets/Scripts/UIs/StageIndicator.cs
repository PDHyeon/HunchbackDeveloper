using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;

    public int stageIdx = 1;

    private void Start()
    {
        stageText.text = stageIdx.ToString();
        GameManager.Instance.monster.monsterHelthSystem.OnDeath += UpdateStageUI;
    }

    private void UpdateStageUI()
    {
        stageIdx++;
        stageText.text = stageIdx.ToString();
    }
}
