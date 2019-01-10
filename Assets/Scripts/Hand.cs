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
    [HideInInspector] private Card card;
    [HideInInspector] private int handSize;
    [HideInInspector] private bool handIsFull = false;

    #region Getsetters
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
    #endregion

    // Use this for initialization
    void Start ()
    {
        handSize = GetComponentsInChildren<CardUI>(true).Length;
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(drawKey) && THandler.CurrentPlayer == Player) //draw a card when the key is pressed
        {
            DrawCard();           
        }

        if (Input.GetKeyDown(shuffleKey))
        {
            Debug.Log("Trying to shuffle deck");
            deck.shuffleCards();
        }
    }

    public void DrawCard()
    {
        bool _canDraw = CheckIfHandIsFull();
        card = deck.drawCard(_canDraw); //Tell the deck we want a card and save it as _card
        if (card != null)
        {
            for (int i = 0; i < handSize; i++) //search for inactive cards in hand
            {
                CardUI _cardToUpdate = gameObject.transform.GetChild(i).GetComponent<CardUI>();
                if (!_cardToUpdate.isActive)
                {
                    _cardToUpdate.updateCard(card);
                    card.OnDraw();

                    break;
                }
            }
        }
        else
        {
            Debug.Log("Card is null");
        }
    }

    public void DrawCards(int cards)
    {
        for (int i = 0; i < cards; i++)
        {
            bool _canDraw = CheckIfHandIsFull();
            card = deck.drawCard(_canDraw); //Tell the deck we want a card and save it as _card
            if (card != null)
            {
                for (int j = 0; j < handSize; j++) //search for inactive cards in hand
                {
                    CardUI _cardToUpdate = gameObject.transform.GetChild(j).GetComponent<CardUI>();
                    if (!_cardToUpdate.isActive)
                    {
                        _cardToUpdate.updateCard(card);
                        card.OnDraw();

                        break;
                    }
                }
            }
            else
            {
                Debug.Log("Card is null");
            }
        }
        
    }
    
    public bool CheckIfHandIsFull()
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

        return handIsFull;
    }
    

}
