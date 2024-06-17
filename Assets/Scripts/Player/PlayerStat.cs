using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    float attackIncreaseAmount = 1f;
    float attackIncreaseAmountMultiplier = 1.1f;

    public float autoAttackDamage { get; private set; }
    float autoAttackIncreaseAmount = 0.5f;
    float autoattackIncreaseAmountMultiplier = 1.05f;
    public float autoAttackSpeed { get; private set; } = 1f;
    float autoAttackSpeedIncreseAmount = 0.98f;


    public void ModifyDamageUpgrade()
    {
        attackDamage += attackIncreaseAmount;
        ApplyAttackMultiplier();
    }

    // 다음 공격력 증가량을 배가 시키기 위해 사용함.
    public void ApplyAttackMultiplier()
    {
        attackIncreaseAmount *= attackIncreaseAmountMultiplier;
    }

    // 자동 공격 데미지 증가
    public void AddAutoAttackDamage()
    {
        autoAttackDamage += autoAttackIncreaseAmount;
        ApplyAutoAttackMultiplier();
    }

    public void ApplyAutoAttackMultiplier()
    {
        autoAttackIncreaseAmount *= autoattackIncreaseAmountMultiplier;
    }
    // 자동 공격의 빈도를 업그레이드 할 때 적용
    public void AddAutoAttackSpeed()
    {
        autoAttackSpeed *= autoAttackSpeedIncreseAmount;
    }
}
