using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpgrade : MonoBehaviour
{
    public void ClickAttackUpgradeButton()
    {
        GameManager.Instance.player.playerStat.ModifyDamageUpgrade();
    }

    public void ClickAutoAttackDamageUpgradeButton()
    {
        GameManager.Instance.player.playerStat.AddAutoAttackDamage();
    }

    public void ClickAutoAttackSpeedUpgradeButton()
    {
        GameManager.Instance.player.playerStat.AddAutoAttackSpeed();
    }
}
