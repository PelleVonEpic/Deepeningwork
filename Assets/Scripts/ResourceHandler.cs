﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour {
    
    [Header("Health")]
    [SerializeField] private int player1Health;
    [SerializeField] private int player2Health;

    [Header("Energy")]
    [SerializeField] private int player1Energy;
    [SerializeField] private int player2Energy;

    [Header("References")]
    [SerializeField] private Text p1HealthText;
    [SerializeField] private Text p2HealthText;
    [SerializeField] private Text p1EnergyText;
    [SerializeField] private Text p2EnergyText;
    [SerializeField] private TurnHandler tHandler;

    #region Getsetters
    public int Player1Health
    {
        get
        {
            return player1Health;
        }

        set
        {
            player1Health = value;
        }
    }

    public int Player2Health
    {
        get
        {
            return player2Health;
        }

        set
        {
            player2Health = value;
        }
    }

    public int Player1Energy
    {
        get
        {
            return player1Energy;
        }

        set
        {
            player1Energy = value;
        }
    }

    public int Player2Energy
    {
        get
        {
            return player2Energy;
        }

        set
        {
            player2Energy = value;
        }
    }

    #endregion

    public void UpdateHealth()
    {
        p1HealthText.text = player1Health.ToString();
        p2HealthText.text = Player2Health.ToString();
    }

    public void UpdateEnergy()
    {
        p1EnergyText.text = player1Energy.ToString();
        p2EnergyText.text = player2Energy.ToString();
    }

    public bool CheckIfICanPlayCard(Card c)
    {
        bool _canPlayCard = false;
        int _energy;
        int cost = c.CastingCost;
        Player p = c.Player;
        if (p == Player.Player1)
        {
            _energy = player1Energy;
        }
        else
        {
            _energy = player2Energy;
        }

        if (cost <= _energy)
        {
            _canPlayCard = true;
            ReduceEnergy(cost, p);
        }
        else
        {
            Debug.Log("You don't have enough Energy to play that card");
        }
        
        return _canPlayCard;
    }
    public void ReduceEnergy(int amount, Player p)
    {
        if (p == Player.Player1)
        {
            player1Energy -= amount;
        }
        else
        {
            Player2Energy -= amount;
        }
        UpdateEnergy();

    }

    public void DealDamageToPlayer(int amount, bool targetEnemy, Player caster)
    {
        if (targetEnemy)
        {
            if (caster == Player.Player2)
            {
                player1Health -= amount;
            }
            else
            {
                player2Health -= amount;
            }
        }
        else
        {
            if (caster == Player.Player1)
            {
                player1Health -= amount;
            }
            else
            {
                player2Health -= amount;
            }
        }
        UpdateHealth();
    }
    
    // Use this for initialization
    void Start () {
        UpdateHealth();
        UpdateEnergy();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
