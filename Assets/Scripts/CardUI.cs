using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler {

    [SerializeField] Image cardImage;
    [SerializeField] Text cardName;
    [SerializeField] Text cardDescription;
    [SerializeField] Text cardCost;
    [HideInInspector] Player player;
    [HideInInspector] private TurnHandler tHandler;
    [HideInInspector] private ResourceHandler rHandler;
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
        rHandler = GetComponentInParent<Hand>().RHandler;
        tHandler = GetComponentInParent<Hand>().THandler;
        player = GetComponentInParent<Hand>().Player;
        gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tHandler.CurrentPlayer == player)
        {
            if (rHandler.CheckIfICanPlayCard(cardReference))
            {
                cardReference.OnPlay();
                gameObject.SetActive(false);
                isActive = false;
                cardReference = null;
            }
            
        }
        else
        {
            Debug.Log("Not your turn!");
        }
    }
}
