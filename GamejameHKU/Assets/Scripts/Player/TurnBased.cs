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
            //SetButtonsInteractable(false);
            return;
        }

        _playerTurn = false;
        //Invoke(nameof(DragonTurn), 1.5f);
    }
    void EnemyTurn()
    {
        int damage = Random.Range(5, 15);
        playerHealth.TakeDamage(damage);

        if (playerHealth.IsDead())
        {
            Debug.Log("you fucking died");
            //SetButtonsInteractable(false);
            return;
        }

        _playerTurn = true;
    }

    void SetButtonsInteractable(bool state)
    {
        AttackButton1.interactable = state;
        AttackButton2.interactable = state;
        AttackButton3.interactable = state;
    }
}


