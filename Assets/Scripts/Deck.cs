using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    [SerializeField] private List<Card> deckList = new List<Card>();
    [SerializeField] private List<Card> cards;


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

            Debug.Log("Remaining cards in deck: " + cards.Count);

            return cardToDraw;
        }
        else
        {
            Debug.Log("can't draw, full hand!");
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

        Debug.Log("Deck Shuffled");
        return;
    }




	// Use this for initialization
	void Start () {

        for (int i = 0; i < deckList.Count; i++)
        {
            Card c = deckList[i];
            cards.Add(c);
            cards[i].Id = i+1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
