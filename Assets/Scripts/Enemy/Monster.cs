using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public HealthSystem monsterHelthSystem;

    public Slider hpBar;

    private SpriteRenderer monsterSprite;
    public float currentHP { get; set; } = 50f;
    public float maxHP { get; private set; } = 50f;

    private float hpMultiplier = 1.1f;

    private float rewardGold = 100;

    private float rewardMultiplier = 1.2f;

    private void Awake()
    {
        monsterHelthSystem = GetComponent<HealthSystem>();
        monsterHelthSystem.OnDamage += UpdateHPBarUI;
        monsterHelthSystem.OnDeath += OnDeath;
        monsterSprite = GetComponent<SpriteRenderer>();
        monsterHelthSystem.OnKillFailed += KillFailed;
    }

    public void UpdateHPBarUI()
    {
        hpBar.value = currentHP / maxHP;
    }

    public void ResetHPBarUI()
    {
        ResetHP();
        hpBar.value = 1;
    }

    public void ResetHP(bool killFailed = false)
    {
        if(!killFailed) maxHP *= hpMultiplier;
        currentHP = maxHP;
    }

    public void OnDeath()
    {
        ResetHPBarUI();
        GameManager.Instance.player.GetGold(rewardGold);
        rewardGold *= rewardMultiplier;
    }

    public void KillFailed()
    {
        ResetHP(true);
    }
}
