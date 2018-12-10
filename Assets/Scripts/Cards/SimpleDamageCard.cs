using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class SimpleDamageCard : Card {

    [SerializeField] private ResourceHandler rhandler;
    [SerializeField] private int damage;

	public override void OnPlay()
    {
        rhandler.DealDamageToPlayer(damage, true);

    }

    void Start()
    {
        rhandler = FindObjectOfType<ResourceHandler>();


    }
}
