using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어와 관련된 여러 정보를 들고 있는 클래스
    // ex) 플레이어 상태 등
    public PlayerStat playerStat;
    public PlayerController playerController;

    public float gold { get; private set; } = 0f;
    float goldMultiplier = 1f;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();
        playerController = GetComponent<PlayerController>();
    }

    public void GetGold(float gainAmount)
    {
        gold += gainAmount;
    }
}
