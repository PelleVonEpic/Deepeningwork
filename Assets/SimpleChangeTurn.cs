using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleChangeTurn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TurnHandler tHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        tHandler.ChangePlayerTurn();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
