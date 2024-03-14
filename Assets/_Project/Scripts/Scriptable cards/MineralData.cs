using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Card/New Mineral Card", order = 2)]
public class MineralData : ScriptableObject
{
    public int id;
    public string expansionID;
    public string cardName;
    public enum Element
    {
        Aurora,
        Corona,
        Flash,
    }
    [field: SerializeField]
    public Element elementType;
    public Sprite cardFrontSprite;
    public Sprite cardArt;
    public Sprite cardBackSprite;
}
