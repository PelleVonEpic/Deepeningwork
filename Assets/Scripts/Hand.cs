using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {


    [SerializeField] private KeyCode drawKey;
    [SerializeField] private KeyCode shuffleKey;
    [SerializeField] private Deck deck;
    [SerializeField] private Player player;
    [SerializeField] private TurnHandler tHandler;
    [SerializeField] private ResourceHandler rHandler;
    [HideInInspector] private Card _card;
    [HideInInspector] private int handSize;
    [HideInInspector] private bool handIsFull = false;
    [HideInInspector] private List<CardUI> cardsInHand = new List<CardUI>();

    public ResourceHandler RHandler
    {
        get
        {
            return rHandler;
        }

        set
        {
            rHandler = value;
        }
    }

    public TurnHandler THandler
    {
        get
        {
            return tHandler;
        }

        set
        {
            tHandler = value;
        }
    }

    public Player Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }


    // Use this for initialization
    void Start ()
    {
        handSize = GetComponentsInChildren<CardUI>(true).Length;
        Debug.Log(handSize);
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(drawKey) && THandler.CurrentPlayer == Player) //draw a card when the key is pressed
        {
            CheckIfHandIsFull();
            _card = deck.drawCard(handIsFull); //Tell the deck we want a card and save it as _card
            if (_card != null)
            {
                for (int i = 0; i < handSize; i++) //search for inactive cards in hand
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
