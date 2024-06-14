using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : CharacterStat
{
    public float hp { get; private set; }
    
    public void DecreaseHP(float damage)
    {
        hp -= damage;
    }
}
