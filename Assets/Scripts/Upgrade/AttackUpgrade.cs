using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpgrade : MonoBehaviour
{
    public void ClickAttackUpgradeButton()
    {
        if(GameManager.Instance.CheckCost())
            GameManager.Instance.player.playerStat.ModifyDamageUpgrade();
    }

    public void ClickAutoAttackDamageUpgradeButton()
    {
        if (GameManager.Instance.CheckCost())
            GameManager.Instance.player.playerStat.AddAutoAttackDamage();
    }

    public void ClickAutoAttackSpeedUpgradeButton()
    {
        if (GameManager.Instance.CheckCost())
            GameManager.Instance.player.playerStat.AddAutoAttackSpeed();
    }
}
