using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour {
    
    [Header("Health")]
    [SerializeField] private int player1Health;
    [SerializeField] private int player2Health;

    [Header("Energy")]
    [SerializeField] private int baseEnergy;
    [SerializeField] private int player1Energy;
    [SerializeField] private int player2Energy;
    [SerializeField] private int player1ExtraEnergy;
    [SerializeField] private int player2ExtraEnergy;

    [Header("Armor")]
    [SerializeField] private int player1Armor;
    [SerializeField] private int player2Armor;

    [Header("References")]
    [SerializeField] private Text p1HealthText;
    [SerializeField] private Text p2HealthText;
    [SerializeField] private Text p1EnergyText;
    [SerializeField] private Text p2EnergyText;
    [SerializeField] private Text p1ArmorText;
    [SerializeField] private Text p2ArmorText;
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

    public int Player2Armor
    {
        get
        {
            return player2Armor;
        }

        set
        {
            player2Armor = value;
        }
    }

    public int Player1Armor
    {
        get
        {
            return player1Armor;
        }

        set
        {
            player1Armor = value;
        }
    }

    public int Player1ExtraEnergy
    {
        get
        {
            return player1ExtraEnergy;
        }

        set
        {
            player1ExtraEnergy = value;
        }
    }

    public int Player2ExtraEnergy
    {
        get
        {
            return player2ExtraEnergy;
        }

        set
        {
            player2ExtraEnergy = value;
        }
    }

    public int BaseEnergy
    {
        get
        {
            return baseEnergy;
        }

        set
        {
            baseEnergy = value;
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

    public void UpdateArmor()
    {
        p1ArmorText.text = player1Armor.ToString();
        p2ArmorText.text = player2Armor.ToString();
    }

    public void SetEnergy(Player player)
    {
        if (player == Player.Player1)
        {
            Player1Energy = baseEnergy + Player1ExtraEnergy;
        }
        else
        {
            Player2Energy = baseEnergy + Player2ExtraEnergy;
        }
        UpdateEnergy();
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

    public void HealPlayer(int amount, Player target)
    {
        if (target == Player.Player1)
        {
            Player1Health += amount;
        }
        else if (target == Player.Player2)
        {
            Player2Health += amount;
        }
        UpdateHealth();
    }

    public int CalculatePlayerDamage(int damage, int armor)
    {
        int _damageToDeal = damage - armor;

        if (_damageToDeal <= 0)
        {
            _damageToDeal = 1;
        }


        return _damageToDeal;
    }

    
    // Use this for initialization
    void Start () {
        UpdateHealth();
        UpdateEnergy();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateArmor();
		
	}
}
