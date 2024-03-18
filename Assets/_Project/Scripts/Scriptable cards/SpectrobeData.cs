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
        Adult,
        Evolved,
    }
    [field: SerializeField]
    public Type cardType;
    public Sprite type;
    public string artworkPath;
    public string chAttackName;
    public string chAttackDescription;

    //Sets the name of the SO automatically asigning it the same name as the asset
    private void OnValidate()
    {
        spectrobeName = name;
    }
}
