using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾�� ���õ� ���� ������ ��� �ִ� Ŭ����
    // ex) �÷��̾� ���� ��
    PlayerStat playerStat;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();
    }
}
