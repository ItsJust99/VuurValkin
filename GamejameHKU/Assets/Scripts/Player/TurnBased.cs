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
        
    }

    public void Update()
    {
        
    }

}


