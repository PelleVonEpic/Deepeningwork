using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject {

    [Header("Action Info")]
    [SerializeField] private String actionName;
    [SerializeField] private int id;
    [SerializeField] private int cost;
    [SerializeField] private enum Type
    {
        Attack,
        heal,
        Move
    }
    [SerializeField] private Type type;

    #region Getsetters
    public string ActionName
    {
        get
        {
            return actionName;
        }

        set
        {
            actionName = value;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
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

    #endregion


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
