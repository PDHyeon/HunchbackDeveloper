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

    // ���� ���ݷ� �������� �谡 ��Ű�� ���� �����.
    public void ApplyAttackMultiplier()
    {
        attackIncreaseAmount *= attackIncreaseAmountMultiplier;
    }

    // �ڵ� ���� ������ ����
    public void AddAutoAttackDamage()
    {
        autoAttackDamage += autoAttackIncreaseAmount;
        ApplyAutoAttackMultiplier();
    }

    public void ApplyAutoAttackMultiplier()
    {
        autoAttackIncreaseAmount *= autoattackIncreaseAmountMultiplier;
    }
    // �ڵ� ������ �󵵸� ���׷��̵� �� �� ����
    public void AddAutoAttackSpeed()
    {
        autoAttackSpeed *= autoAttackSpeedIncreseAmount;
    }
}
