using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    public Monster monster;

    HealthSystem monsterHealthSystem;

    public Action OnGoldChanged;

    public GameObject particlePrefab; 

    public RequireGoldIndicator requireGoldIndicator;
    public StageIndicator stageIndicator;
    EarnGoldUpgrade earnGold;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        monsterHealthSystem = monster.monsterHelthSystem;
        earnGold = GetComponent<EarnGoldUpgrade>();
    }

    private void Start()
    {
        player.playerController.playerActions.Click.started += PlayerClick;
        StartCoroutine(AutoClick());
    }

    public void PlayerClick(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 0);
        if(hit)
        {
            GameObject go = Instantiate(particlePrefab);
            go.transform.position = mousePos + Vector3.forward * 10;

            Destroy(go, 1f);
            monsterHealthSystem.ChangeHealth(player.playerStat.attackDamage);
        }
    }

    public bool CheckCost()
    {
        if(requireGoldIndicator.UpgradeGold > player.gold)
        {
            return false;
        }

        player.gold -= requireGoldIndicator.UpgradeGold;
        requireGoldIndicator.IncreaseUpgradeCost();
        OnGoldChanged?.Invoke();
        return true;
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            monsterHealthSystem.ChangeHealth(player.playerStat.autoAttackDamage);
            yield return new WaitForSeconds(player.playerStat.autoAttackSpeed);
        }
    }

    public void InitializeSet(float gold, int nowStage, float tapAttackDamage, 
                              float autoAttackDamage, float autoAttackFrequency,
                              float autoIncreaseGold, float autoIncreaseGoldFrequency,
                              float upgradeRequireGold)
    {
        player.gold = gold;
        stageIndicator.stageIdx = nowStage;
        player.playerStat.InitializeSetting(tapAttackDamage, autoAttackDamage, autoAttackFrequency);
        earnGold.autoIncreaseGold = autoIncreaseGold;
        earnGold.autoIncreasingGoldTime = autoIncreaseGoldFrequency;
        requireGoldIndicator.UpgradeGold = upgradeRequireGold;
    }
}
