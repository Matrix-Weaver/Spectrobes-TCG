using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Card/New Child Spectrobe Card", order = 2)]
public class ChildData : ScriptableObject
{
    public int ID;
    public string expansionID;
    public string spectrobeName;
    public int mineralCost;
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
    public string artworkPath;
    public string AbilityName;
    public string AbilityDescription;
    private void OnValidate()
    {
        //Sets the spectrobe name to the one of the file when creating the file
        spectrobeName = name;
    }
}
