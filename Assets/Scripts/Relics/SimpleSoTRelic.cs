using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class SimpleSoTRelic : Relic {

    [SerializeField] private ResourceHandler rhandler;
    [SerializeField] private int damage;

    public override void OnEnter()
    {
        rhandler = FindObjectOfType<ResourceHandler>();
    }

    public override void StartOfTurn()
    {
        rhandler.DealDamageToPlayer(damage, true, RelicOwner);
    }
}
