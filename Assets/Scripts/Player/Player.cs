using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾�� ���õ� ���� ������ ��� �ִ� Ŭ����
    // ex) �÷��̾� ���� ��
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
