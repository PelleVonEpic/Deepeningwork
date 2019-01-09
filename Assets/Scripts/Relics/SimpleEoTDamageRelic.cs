using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class SimpleEoTDamageRelic : Relic {

    [SerializeField] private ResourceHandler rhandler;
    [SerializeField] private int damage;

    public override void OnEnter()
    {
        rhandler = FindObjectOfType<ResourceHandler>();
    }

    public override void EndOfTurn()
    {
        rhandler.DealDamageToPlayer(damage, true, RelicOwner);
    }
}
