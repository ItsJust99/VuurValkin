using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnBased : MonoBehaviour
{
    [SerializeField] Button AttackButton1; 
    [SerializeField] Button AttackButton2;
    [SerializeField] Button AttackButton3;

    public DragonHealth dragonHeath;
    public PlayerHealth playerHealth;

    //Dragon attack 
    public Animator enemyAnimator;

    //player attack
    public Animator playerAnimator;

    private bool _playerTurn;


    public void Start()
    {
        AttackButton1.onClick.AddListener(() => OnPlayerAttack(10, "AttackLeft"));
        AttackButton2.onClick.AddListener(() => OnPlayerAttack(15, "AttackFront"));
        AttackButton3.onClick.AddListener(() => OnPlayerAttack(5, "AttackRight"));

        _playerTurn = true;   
        SetButtons(true);
    }

    public void OnPlayerAttack(int damage, string animationTrigger)
    {
        if (!_playerTurn)
        {
            return;
        }

        if (playerAnimator != null && AttackButton1)
        {
            playerAnimator.SetBool(animationTrigger, true);
            Invoke(nameof(ResetAttackAnimation), 1f);
        }

        dragonHeath.TakeDamage(damage);
        Debug.Log("Dragon takes damage");

        if (dragonHeath.IsDead())
        {
            Debug.Log("Dragon takes damage");
            SetButtons(false);
            return;
        }

        _playerTurn = false;
        SetButtons(false);
        Invoke(nameof(DragonTurn), 1.5f); //Delay before dragon starts 
    }
    void DragonTurn()
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("Attack1", true);
            Invoke(nameof(ResetAttackAnimation), 1f);
            Invoke(nameof(dammagePlayerOwO), 1f);

            
        }

        //int damage = Random.Range(5, 16);
        //playerHealth.TakeDamage(damage);


        if (playerHealth.IsDead())
        {
            SetButtons(false);
            return;
        }

        Invoke(nameof(BackToPlayerTurn), 2f); //Delay before player starts
    }
    void dammagePlayerOwO()
    {
        int damage = Random.Range(5, 16);
        playerHealth.TakeDamage(damage);
    }

    void ResetAttackAnimation()
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("Attack1", false);
        }
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("AttackFront", false);
            playerAnimator.SetBool("AttackLeft", false);
            playerAnimator.SetBool("AttackRight", false);
        }
    }

    void BackToPlayerTurn()
    {
        if (!playerHealth.IsDead())
        {
            SetButtons(true);
            _playerTurn = true;
        }
    }
    void SetButtons(bool state)
    {
        AttackButton1.interactable = state;
        AttackButton2.interactable = state;
        AttackButton3.interactable = state;
    }
}


