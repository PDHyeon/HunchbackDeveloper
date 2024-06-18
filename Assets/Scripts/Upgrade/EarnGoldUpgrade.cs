using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnGoldUpgrade : MonoBehaviour
{
    [SerializeField] GoldIndicator goldIndicator;

    public float autoIncreaseGold { get; set; } = 0f;
    private float increasingGoldAddValue = 1f;
    private float addValueIncreaseRate = 1.05f;
    public float autoIncreasingGoldTime { get; set; } = 1f;
    private float autoIncreasingGoldTimeDecreaseRate = 0.98f;

    private void Start()
    {
        StartCoroutine(AutoIncreaseGold());
    }
    public void ClickUpgradeAutoIncreasingGold()
    {
        if (GameManager.Instance.CheckCost())
        {
            autoIncreaseGold += increasingGoldAddValue;
            increasingGoldAddValue *= addValueIncreaseRate;
        }
    }

    public void ClickDecreaseEarnGoldTime()
    {
        if (GameManager.Instance.CheckCost())
            autoIncreasingGoldTime *= autoIncreasingGoldTimeDecreaseRate;
    }

    IEnumerator AutoIncreaseGold()
    {
        while (true)
        {
            GameManager.Instance.player.GetGold(autoIncreaseGold);
            goldIndicator.UpdateGoldUI();

            yield return new WaitForSeconds(autoIncreasingGoldTime);
        }
    }

    public void InitSet()
    {
        autoIncreaseGold = 0f;
        autoIncreasingGoldTime = 1f;
    }
}
