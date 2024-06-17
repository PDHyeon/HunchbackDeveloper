using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    public Monster monster;

    HealthSystem monsterHealthSystem;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        monsterHealthSystem = monster.monsterHelthSystem;

        Debug.Log(monster);
    }

    private void Start()
    {
        player.playerController.playerActions.Click.started += PlayerClick;
    }


    public void PlayerClick(InputAction.CallbackContext context)
    {
        monsterHealthSystem.ChangeHealth(player.attack);
        Debug.Log("클릭 처리");
    }
}
