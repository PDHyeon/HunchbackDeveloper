using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.playerController.playerActions.Click.started += OnClick;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        // ���Ϳ��� �������� ���� 
        // ���� ü�� ���� (���ݷ� �����ؾ� ��.)
        Debug.Log("Ŭ�� ó��");
    }
}
