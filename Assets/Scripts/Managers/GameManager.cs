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
    [SerializeField] float autoAttackDealyTime = 0.1f;

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
        monsterHealthSystem.ChangeHealth(player.attack);
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            monsterHealthSystem.ChangeHealth(player.attack);
            yield return new WaitForSeconds(autoAttackDealyTime);
        }
    }
}
