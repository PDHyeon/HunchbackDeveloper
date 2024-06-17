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
        hpBar.value = 1;
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        ResetHPBarUI();
        // Á×¾úÀ» ¶§ Ã³¸® + °ñµå Áö±Þ
    }
}
