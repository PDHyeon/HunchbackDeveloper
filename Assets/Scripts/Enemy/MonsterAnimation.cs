using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    private static readonly int isAttacked = Animator.StringToHash("IsAttacked");

    Animator animator;
    HealthSystem monsterHelthSystem;

    private void Start()
    {
        animator = GetComponent<Animator>();

        monsterHelthSystem = GameManager.Instance.monster.monsterHelthSystem;
        monsterHelthSystem.OnDamage += OnHit;
    }

    private void OnHit()
    {
        animator.SetTrigger(isAttacked);
        Debug.Log("asfas");
    }
}
