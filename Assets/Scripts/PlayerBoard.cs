using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour {

    [SerializeField] private List<BoardSpace> boardSpaces = new List<BoardSpace>();
    [SerializeField] private Player owner;
    [HideInInspector] private int spaces;

    #region getsetters
    public List<BoardSpace> BoardSpaces
    {
        get
        {
            return boardSpaces;
        }

        set
        {
            boardSpaces = value;
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

    public int Spaces
    {
        get
        {
            return spaces;
        }

        set
        {
            spaces = value;
        }
    }

    #endregion


    public void PlayRelicToBoard(Relic r)
    {
        foreach(BoardSpace b in boardSpaces)
        {
            if (b.IsActive == true)
            {
                continue;
            }

            else
            {
                b.RelicEnter(r);
                break;
            }
        }

    }

    public bool CheckIfThereIsSpace()
    {
        foreach (BoardSpace b in boardSpaces)
        {
            if (!b.IsActive)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayStartOfTurnEffects()
    {
        foreach(BoardSpace b in boardSpaces)
        {
            if (b.IsActive)
            {
                b.StartOfTurnEffect();
            }
        }

    }

    public void PlayEndOfTurnEffects()
    {
        foreach(BoardSpace b in boardSpaces)
        {
            if (b.IsActive)
            {
                b.EndOfTurnEffect();
            }
        }
    }


    // Use this for initialization
    void Start () {

        Spaces = GetComponentsInChildren<BoardSpace>(true).Length;

        for (int i = 0; i < Spaces; i++)
        {
            boardSpaces.Add(gameObject.transform.GetChild(i).GetComponent<BoardSpace>());

        }

        foreach (BoardSpace b in boardSpaces)
        {
            b.Owner = Owner;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
