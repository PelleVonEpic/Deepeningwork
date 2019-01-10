using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BoardSpace : MonoBehaviour, IPointerClickHandler  {

    [HideInInspector] private Relic relic;
    [SerializeField] private Player owner;
    [HideInInspector] private Image relicImage;
    [HideInInspector] private bool isActive;
    [HideInInspector] private Board board;

    #region getsetters
    public Relic Relic
    {
        get
        {
            return relic;
        }

        set
        {
            relic = value;
        }
    }

    public Player Owner
    {
        get
        {
            return owner;
        }

        set
        {
            owner = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
        }
    }

    #endregion

    private void Start()
    {
        gameObject.SetActive(false);
        IsActive = false;
        board = FindObjectOfType<Board>();
        
    }

    public void RelicEnter(Relic relicToPlay)
    {

        GetComponent<Image>().sprite = relicToPlay.RelicImage;
        relic = relicToPlay;
        relic.RelicOwner = owner;
        gameObject.SetActive(true);
        IsActive = true;
        relic.OnEnter();

    }

    public void RelicRemove()
    {
        relic.OnExit();
        GetComponent<Image>().sprite = null;
        relic = null;
        gameObject.SetActive(false);
        IsActive = false;
    }

    public void EndOfTurnEffect()
    {
        relic.RelicOwner = owner;
        relic.EndOfTurn();

    }

    public void StartOfTurnEffect()
    {
        relic.RelicOwner = owner;
        relic.StartOfTurn();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (board.RelicsToBeRemoved > 0)
        {
            RelicRemove();
            board.RelicsToBeRemoved--;
        }
        
    }
}
