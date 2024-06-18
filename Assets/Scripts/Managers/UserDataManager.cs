using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    UserData data = new UserData();

    private void Start()
    {
        UserData userData = LoadUserData();
        if (userData != null)
        {
            GameManager.Instance.InitializeSet(userData.gold, userData.nowStage,
                                               userData.tapAttackDamage, userData.autoAttackDamage,
                                               userData.autoAttackFrequency, userData.autoIncreaseGold,
                                               userData.autoIncreasingGoldFrequency, userData.upgradeRequirementGold);
        }
        else
        {
            Init();
        }
    }

    private void SaveUserData()
    {
        data.gold = GameManager.Instance.player.gold;
        data.nowStage = GameManager.Instance.stageIndicator.stageIdx;
        data.tapAttackDamage = GameManager.Instance.player.playerStat.attackDamage;
        data.autoAttackDamage = GameManager.Instance.player.playerStat.autoAttackDamage;
        data.autoAttackFrequency = GameManager.Instance.player.playerStat.autoAttackSpeed;
        data.autoIncreaseGold = GameManager.Instance.GetComponent<EarnGoldUpgrade>().autoIncreaseGold;
        data.autoIncreasingGoldFrequency = GameManager.Instance.GetComponent<EarnGoldUpgrade>().autoIncreasingGoldTime;
        data.upgradeRequirementGold = GameManager.Instance.requireGoldIndicator.UpgradeGold;

        //json Á÷·ÄÈ­
        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/userData.txt", jsonData);
    }

    private UserData LoadUserData()
    {
        if (File.Exists(Application.persistentDataPath + "/userData.txt"))
        {
            string load = File.ReadAllText(Application.persistentDataPath + "/userData.txt");

            UserData loadData = JsonUtility.FromJson<UserData>(load);

            return loadData;
        }

        return null;
    }

    private void OnApplicationQuit()
    {
        SaveUserData();
    }

    private void Init()
    {
        data.gold = 0;
        data.nowStage = 1;
        GameManager.Instance.player.playerStat.InitializeSetting();
        GameManager.Instance.GetComponent<EarnGoldUpgrade>().InitSet();
        data.upgradeRequirementGold = 100f;
    }
}

[System.Serializable]
public class UserData
{
    public float gold;
    public int nowStage;
    public float tapAttackDamage;
    public float autoAttackDamage;
    public float autoAttackFrequency;
    public float autoIncreaseGold;
    public float autoIncreasingGoldFrequency;
    public float upgradeRequirementGold;
}
