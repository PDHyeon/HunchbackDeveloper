using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnGoldUpgrade : MonoBehaviour
{
    [SerializeField] GoldIndicator goldIndicator;

    private float autoIncreaseGold = 0f;
    private float increasingGoldAddValue = 1f;
    private float addValueIncreaseRate = 1.05f;
    private float autoIncreasingGoldTime = 1f;
    private float autoIncreasingGoldTimeDecreaseRate = 0.98f;

    private void Start()
    {
        StartCoroutine(AutoIncreaseGold());
    }
    public void ClickUpgradeAutoIncreasingGold()
    {
        autoIncreaseGold += increasingGoldAddValue;        
        increasingGoldAddValue *= addValueIncreaseRate;
        Debug.Log(autoIncreaseGold);
    }

    public void ClickDecreaseEarnGoldTime()
    {
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
}
