using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Card/New Mineral Card", order = 3)]
public class MineralData : ScriptableObject
{
    public int id;
    public string expansionID;
    public string mineralName;
    public enum Element
    {
        Aurora,
        Corona,
        Flash,
    }
    [field: SerializeField]
    public Element elementType;
    public Sprite cardArt;
}
