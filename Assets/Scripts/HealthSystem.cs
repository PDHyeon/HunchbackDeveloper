using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Action OnDamage;
    public Action OnDeath;
    public Action OnKillFailed;

    Monster monster;

    private void Start()
    {
        monster = GameManager.Instance.monster;
    }

    public void ChangeHealth(float value)
    {
        if(monster.currentHP <= 0)
        {
            CallDeath();
            return;
        }

        OnDamage?.Invoke();
        monster.currentHP -= value;
    }
    void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
