using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {


    [SerializeField] private KeyCode drawKey;
    [SerializeField] private KeyCode shuffleKey;
    [SerializeField] private Deck deck;
    [HideInInspector] private Card _card;
    [HideInInspector] private int handSize;
    [HideInInspector] private bool handIsFull = false;
    [HideInInspector] private List<CardUI> cardsInHand = new List<CardUI>();
    

    // Use this for initialization
    void Start ()
    {
        handSize = GetComponentsInChildren<CardUI>(true).Length;
        Debug.Log(handSize);
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(drawKey)) //draw a card when the key is pressed
        {
            CheckIfHandIsFull();
            _card = deck.drawCard(handIsFull); //Tell the deck we want a card and save it as _card
            if (_card != null)
            {
                for (int i = 0; i < handSize; i++) //search for inactive cards
                {
                    CardUI _cardToUpdate = gameObject.transform.GetChild(i).GetComponent<CardUI>();
                    if (!_cardToUpdate.isActive)
                    {
                        _cardToUpdate.updateCard(_card);
                        _card.OnDraw();
                        
                        break;

                    }
                }
            }
            
            CheckIfHandIsFull();
            
        }

        if (Input.GetKeyDown(shuffleKey))
        {
            Debug.Log("Trying to shuffle deck");
            deck.shuffleCards();
            
        }

    }

    //Thought process
    //Add Card to list
    //Save the ID of the card

    public void CheckIfHandIsFull()
    {
        int c = GetComponentsInChildren<CardUI>().Length;
        if (c >= handSize)
        {
            handIsFull = true;
            Debug.Log("Hand is full");

        }
        else
        {
            handIsFull = false;
        }

        Debug.Log("Cards in hand: " + c + " Maximum Cards: " + handSize);
    }

    public void AddToHandList(CardUI CUI)
    {
        cardsInHand.Add(CUI);
    }

}
