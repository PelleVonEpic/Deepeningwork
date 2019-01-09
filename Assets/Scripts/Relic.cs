using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]

public class Relic : ScriptableObject {

    [SerializeField] private string relicName;
    [SerializeField] private int id;
    [SerializeField] private Sprite relicImage;
    [SerializeField] private string relicDescription;
    [HideInInspector] private Player relicOwner;

    #region getsetters
    public string RelicName
    {
        get
        {
            return relicName;
        }

        set
        {
            relicName = value;
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

    public Sprite RelicImage
    {
        get
        {
            return relicImage;
        }

        set
        {
            relicImage = value;
        }
    }

    public string RelicDescription
    {
        get
        {
            return relicDescription;
        }

        set
        {
            relicDescription = value;
        }
    }

    public Player RelicOwner
    {
        get
        {
            return relicOwner;
        }

        set
        {
            relicOwner = value;
        }
    }

    #endregion

    public virtual void EndOfTurn()
    {

    }

    public virtual void StartOfTurn()
    {

    }

    public virtual void OnEnter()
    {

    }
    
    public virtual void OnExit()
    {

    }

}
