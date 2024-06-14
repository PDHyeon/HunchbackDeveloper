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
        // 몬스터에게 데미지를 적용 
        // 몬스터 체력 감소 (공격력 적용해야 함.)
        Debug.Log("클릭 처리");
    }
}
