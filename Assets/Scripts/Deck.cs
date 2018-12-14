using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    [SerializeField] private List<Card> deckList = new List<Card>();
    [SerializeField] private List<Card> cards;
    [SerializeField] private Player player;


    public Card drawCard(bool fullHand)
    {
        if (!fullHand)
        {
            
            if (cards.Count <= 0)
            {
                return null;
            }
            Card cardToDraw;

            cardToDraw = cards[0];

            cards.Remove(cards[0]);

            return cardToDraw;
        }
        else
        {
            Debug.Log("Can't draw, full hand!");
            return null;
        }
    }

    public void shuffleCards()
    {

        for (int i = 0; i < cards.Count; i++)
        {

            Card temp = cards[i];
            int randomIndex = UnityEngine.Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;

        }
    }
    
	// Use this for initialization
	void Awake () {
        cards = new List<Card>();
        for (int i = 0; i < deckList.Count; i++)
        {
            Card c = Instantiate(deckList[i]);

            c.Player = player;
            c.Id = i + 1;
            cards.Add(c);
        }
        shuffleCards();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
