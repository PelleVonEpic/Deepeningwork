using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class SimpleDamageCard : Card {

    [HideInInspector] private ResourceHandler rhandler;
    [SerializeField] private int damage;

	public override void OnPlay()
    {
        rhandler = FindObjectOfType<ResourceHandler>();
        rhandler.DealDamageToPlayer(damage, true, Player);

    }

    void Start()
    {
        
        
    }
}
