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
    public float currentHP { get; set; } = 100f;
    public float maxHP { get; private set; } = 100f;

    private float hpMultiplier = 1.1f;

    private float rewardGold = 100;

    private float rewardMultiplier = 1.2f;

    private void Awake()
    {
        monsterHelthSystem = GetComponent<HealthSystem>();
        monsterHelthSystem.OnDamage += UpdateHPBarUI;
        monsterHelthSystem.OnDeath += OnDeath;
        monsterSprite = GetComponent<SpriteRenderer>();
    }

    public void UpdateHPBarUI()
    {
        hpBar.value = currentHP / maxHP;
        Debug.Log(hpBar.value);
    }

    public void ResetHPBarUI()
    {
        ResetHP();
        hpBar.value = 1;
    }

    public void ResetHP()
    {
        maxHP *= hpMultiplier;
        currentHP = maxHP;
    }

    public void OnDeath()
    {
        ResetHPBarUI();
        GameManager.Instance.player.GetGold(rewardGold);
        rewardGold *= rewardMultiplier;
    }
}
