using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾�� ���õ� ���� ������ ��� �ִ� Ŭ����
    // ex) �÷��̾� ���� ��
    public PlayerStat playerStat;
    public PlayerController playerController;

    float gold = 0;
    float goldMultiplier = 1f;

    public float attack { get; private set; } = 1f;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();
        playerController = GetComponent<PlayerController>();
    }
}
