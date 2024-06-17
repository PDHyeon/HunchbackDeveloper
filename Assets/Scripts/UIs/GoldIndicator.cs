using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldIndicator : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private void Start()
    {
        goldText.text = "0";
        GameManager.Instance.monster.monsterHelthSystem.OnDeath += UpdateGoldUI;
    }

    private void UpdateGoldUI()
    {
        goldText.text = GameManager.Instance.player.gold.ToString();
    }
}
