using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾�� ���õ� ���� ������ ��� �ִ� Ŭ����
    // ex) �÷��̾� ���� ��
    public PlayerStat playerStat;
    public PlayerController playerController;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();
        playerController = GetComponent<PlayerController>();
    }
}
