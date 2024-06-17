using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RequireGoldIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI requireGoldTxt;

    public float UpgradeGold = 100;
    private float UpgradeGoldIncreaseRate = 1.1f;

    private void Awake()
    {
        UpdateRequireGoldUI();
    }
    public void IncreaseUpgradeCost()
    {
        UpgradeGold *= UpgradeGoldIncreaseRate;

        UpdateRequireGoldUI();
    }

    private void UpdateRequireGoldUI()
    {
        requireGoldTxt.text = UpgradeGold.ToString("F0") + "G";
    }
}
