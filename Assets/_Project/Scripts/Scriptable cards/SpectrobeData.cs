using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Card/New Spectrobe Card", order = 1)]
public class SpectrobeData : ScriptableObject
{
    public int ID;
    public string expansionID;
    public string spectrobeName;
    public int mineralCost;
    public int hp;
    public int attack;
    public int searchLevel;
    public enum Element
    {
        Aurora,
        Corona,
        Flash,
        Sky,
        Earth
    }

    [field: SerializeField]
    public Element elementType;

    public enum Type
    {
        Child,
        Adult,
        Evolved,
    }

    [field: SerializeField]
    public Type cardType;
    public Sprite cardFrontSprite;
    public Sprite cardArt;
    public Sprite cardBackSprite;
    public string chAttackName;
    public string chAttackDescription;

    public bool CanSearch()
    {
        return cardType == Type.Child;
    }

    private void OnValidate()
    {
        spectrobeName = name;
    }

}
