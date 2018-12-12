using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleHealCard : Card {

    [SerializeField] private int healAmount;
    [HideInInspector] private Player playerToHeal;

    public override void OnPlay()
    {
        ResourceHandler rh = FindObjectOfType<ResourceHandler>();

        if (Player == Player.Player1)
        {
            playerToHeal = Player.Player1;
        }
        else
        {
            playerToHeal = Player.Player1;
        }
        
        rh.HealPlayer(healAmount, playerToHeal);
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
