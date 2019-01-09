using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class SimpleRelicCard : Card {

    [SerializeField] Relic relic;
    [HideInInspector] Board board;


    public override void OnPlay()
    {
        board = FindObjectOfType<Board>();
        board.PlayRelicToOwnBoard(Player, relic);
    }



}
