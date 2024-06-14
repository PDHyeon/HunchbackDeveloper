using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    // ���ݷ��� x�� �����ִ� ����� ����
    public float attackMultiplier { get; private set; } = 1f;
    public float autoAttackDamage { get; private set; } = 0f;
    public float autoAttackSpeed { get; private set; } = 1f;


    public virtual void ModifyDamageUpgrade(float value)
    {
        attackDamage += value;
    }
    public void AddAttackMultiplier(float multiplierValue)
    {
        attackMultiplier += multiplierValue;
    }

    public void AddAutoAttackDamage(float damage)
    {
        autoAttackDamage += damage;
    }

    public void AddAutoAttackSpeed(float attackSpeed)
    {
        autoAttackSpeed += attackSpeed;
    }
}
