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

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        monsterHealthSystem = monster.monsterHelthSystem;
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

        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 10);
        if(hit)
        {
            monsterHealthSystem.ChangeHealth(player.playerStat.attackDamage);
        }
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            monsterHealthSystem.ChangeHealth(player.playerStat.autoAttackDamage);
            yield return new WaitForSeconds(player.playerStat.autoAttackSpeed);
        }
    }
}
