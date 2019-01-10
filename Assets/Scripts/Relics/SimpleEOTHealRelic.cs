using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class SimpleEOTHealRelic : Relic {

    [SerializeField] private int healingAmount;
    [HideInInspector] private ResourceHandler rHandler;

    public override void EndOfTurn()
    {
        rHandler.HealPlayer(healingAmount, RelicOwner);
    }

    public override void OnEnter()
    {
        rHandler = FindObjectOfType<ResourceHandler>();
    }

}
