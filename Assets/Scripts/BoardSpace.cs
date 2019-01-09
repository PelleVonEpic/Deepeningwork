using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSpace : MonoBehaviour {

    [HideInInspector] private Relic relic;
    [SerializeField] private Player owner;
    [HideInInspector] private Sprite relicImage;
    [HideInInspector] private bool isActive;

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

        relicImage = GetComponent<Sprite>();
    }

    public void RelicEnter(Relic relicToPlay)
    {

        relicImage = relicToPlay.RelicImage;
        relic = relicToPlay;
        relic.RelicOwner = owner;
        gameObject.SetActive(true);
        IsActive = true;
        relic.OnEnter();

    }

    public void RelicRemove()
    {
        relic.OnExit();
        relicImage = null;
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

}
