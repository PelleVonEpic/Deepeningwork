﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Card : ScriptableObject {

    [Header("Card Info")]
    [SerializeField] private string cardName;
    [SerializeField] private int id;
    [SerializeField] private Sprite cardImage;
    [SerializeField] private string cardDescription;   
    [SerializeField] private int castingCost;
    [HideInInspector] private Player player;

    #region Getsetters
    public string CardName
    {
        get
        {
            return cardName;
        }

        set
        {
            cardName = value;
        }
    }

    public int CastingCost
    {
        get
        {
            return castingCost;
        }

        set
        {
            castingCost = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public Sprite CardImage
    {
        get
        {
            return cardImage;
        }

        set
        {
            cardImage = value;
        }
    }

    public string CardDescription
    {
        get
        {
            return cardDescription;
        }

        set
        {
            cardDescription = value;
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

    //public List<Action> CardActions
    //{
    //    get
    //    {
    //        return cardActions;
    //    }

    //    set
    //    {
    //        cardActions = value;
    //    }
    //}

    #endregion


    public virtual void OnPlay()
    {

    }

    public virtual void OnDraw()
    {

    }


}
