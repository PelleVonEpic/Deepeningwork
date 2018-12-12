﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler {

    [SerializeField] Image cardImage;
    [SerializeField] Text cardName;
    [SerializeField] Text cardDescription;
    [SerializeField] Text cardCost;
    [SerializeField] Player player;
    [SerializeField] private TurnHandler tHandler;
    [HideInInspector] Card cardReference;
    [HideInInspector] public bool isActive = false;

    public void updateCard(Card c)
    {
        gameObject.SetActive(true);
        isActive = true;
        cardImage.sprite = c.CardImage;
        cardName.text = c.CardName;
        cardDescription.text = c.CardDescription;
        cardCost.text = c.CastingCost.ToString();
        cardReference = c;
    }
    void Start ()
    {
        gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tHandler.CurrentPlayer == player)
        {
            cardReference.OnPlay();
            gameObject.SetActive(false);
            isActive = false;
            cardReference = null;
        }
        else
        {
            Debug.Log("Not your turn!");
        }
    }
}
