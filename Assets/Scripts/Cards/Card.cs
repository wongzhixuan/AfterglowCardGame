using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardClass
{
    Attack,
    Defense,
    Heal,
    Effect
}

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
[System.Serializable]
public class Card : ScriptableObject
{
    public int id;
    public new string name;
    public string description;
    public Sprite artwork;

    public CardClass cardClass; //dropdown menu in inspector

    public int manaCost;
    public int attack;

    public int hp;

    public bool isCardBack;
    public int shield;
    
public void card()
    {

    }
    public void card(int Id, string Name, string Des, Sprite Artwork, CardClass cClass, int ManaCost, int Attack, int Hp, bool IsCardBack)
    {
        id = Id;
        name = Name;
        description = Des;
        artwork = Artwork;
        cardClass = cClass;
        manaCost = ManaCost;
        attack = Attack;
        hp = Hp;
        isCardBack = IsCardBack;

    }

    
}

