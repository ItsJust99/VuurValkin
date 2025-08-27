using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnBased : MonoBehaviour
{
    [SerializeField] Button AttackButton1; 
    [SerializeField] Button AttackButton2;
    [SerializeField] Button AttackButton3;

    public DragonHealth dragonHeath;
    public PlayerHealth playerHealth;

    //Dragon attack 
    public GameObject enemyAttackPrefab; //for now only 1 attack I want 2 in total
    public Transform attackSpawnPoint;


    private bool _playerTurn;


    public void Start()
    {
        AttackButton1.onClick.AddListener(() => OnPlayerAttack(1));
        AttackButton2.onClick.AddListener(() => OnPlayerAttack(2));
        AttackButton3.onClick.AddListener(() => OnPlayerAttack(3));
    }

    public void OnPlayerAttack(int damage)
    {
        if (!_playerTurn)
        {
            return;
        }

        dragonHeath.TakeDamage(damage);
        Debug.Log("Dragon takes damage");

        if (dragonHeath.IsDead())
        {
            Debug.Log("Dragon takes damage");
            SetButtonse(false);
            return;
        }

        _playerTurn = false;
        Invoke(nameof(DragonTurn), 1.5f); //Delay before dragon starts 
    }
    void DragonTurn()
    {
        Instantiate(enemyAttackPrefab, attackSpawnPoint.position, Quaternion.identity);

        Invoke(nameof(BackToPlayerTurn), 2f); //Delay before player starts
    }

    void BackToPlayerTurn()
    {
        if (!playerHealth.IsDead())
        {
            _playerTurn = true;
        }
    }
    void SetButtonse(bool state)
    {
        AttackButton1.interactable = state;
        AttackButton2.interactable = state;
        AttackButton3.interactable = state;
    }
}


