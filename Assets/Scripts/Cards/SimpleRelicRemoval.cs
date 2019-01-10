using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class SimpleRelicRemoval : Card {

    [SerializeField] private int relicsToDestroy;
    [HideInInspector] private Board board;


    public override void OnPlay()
    {
        board = FindObjectOfType<Board>();
        board.RelicsToBeRemoved += relicsToDestroy;
    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
