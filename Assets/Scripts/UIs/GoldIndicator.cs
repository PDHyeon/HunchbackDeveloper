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
        GameManager.Instance.OnGoldChanged += UpdateGoldUI;
        GameManager.Instance.monster.monsterHelthSystem.OnDeath += UpdateGoldUI;
    }

    public void UpdateGoldUI()
    {
        goldText.text = ((int)GameManager.Instance.player.gold).ToString() + " G";
    }
}
