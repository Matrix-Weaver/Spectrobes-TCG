using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Threading;
using SpectrobesTCG;
using UnityEngine;

public class CardZone
{
    private readonly List<Card> cardsList = new List<Card>();
    private GameManager.PlayerIds controllerId;
    private GameManager.PlayerIds ownerId;
    private GroupingType groupingType;
    private Transform placementTransform;
    private int orderInLayer = 0;


    public CardZone(GameManager.PlayerIds playerId)
    {
        ownerId = playerId;
        controllerId = playerId;
    }

    public CardZone(GameManager.PlayerIds playerId, GroupingType groupingType, Transform placementTransform, int orderInLayer)
    {
        ownerId = playerId;
        controllerId = playerId;

        this.groupingType = groupingType;
        this.placementTransform = placementTransform;
        this.orderInLayer = orderInLayer;
    }

    public List<Card> CardsList { get { return cardsList; } }
    public Transform ParentTransform { get { return placementTransform; } }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Adds a <c>card</c> to <c>cardsList</c>.
    /// </summary>
    /// <param name="card"> <c>Card</c> object to be added to <c>cardsList</c>.</param>
    /// <param name="arrangeCards"><c>[Optional]</c><br/>
    /// Determines if <c>cardsList</c> should be arranged after adding <c>card</c>.<para/>
    /// Requires <c>CardZone</c> to have a <c>placementTrasnfrom</c>.</param>
    /// <param name="index"> <c>[Optional]</c><br/>
    /// Index of <c>cardsList</c> at which to add <c>card</c>.<para/>
    /// If index is negative or greater than <c>cardsList.Count</c>, then card will be added to end of <c>cardsList</c>.</param>
    public void AddCard(Card card, Boolean arrangeCards = false, int index = -1)
    {
        card.transform.SetParent(placementTransform);
        if (index >= 0 && index < cardsList.Count)
            cardsList.Insert(index, card);
        else
            cardsList.Add(card);
        if (placementTransform && arrangeCards)
            ArrangeCards();
    }

    /// <summary>
    /// Removes a <c>Card</c> from <c>cardsList</c>.
    /// </summary>
    /// <param name="card"><c>Card</c> object to remove from <c>cardsList</c>.</param>
    public void RemoveCard(Card card)
    {
        cardsList.Remove(card);
    }

    /// <summary>
    /// Randomly sorts <c>cardsList</c>
    /// </summary>
    /// <param name="shouldPurgeVisibility"><c>[Optional]</c><br/>
    /// If cards in <c>cardsList</c> should clear their <c>playerVisibilityIds</c> by calling <see cref="Card.PurgePlayerVisibilityIds"/><para/>
    public void Shuffle(bool shouldPurgeVisibility = false)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = cardsList.Count;
        while (n > 0)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (box[0] >= n * (Byte.MaxValue / n));
            int k = (box[0] % n);
            n--;
            Card card = cardsList[k];
            cardsList[k] = cardsList[n];
            cardsList[n] = card;
            if (shouldPurgeVisibility)
                card.PurgePlayerVisibilityIds();
        }
        ArrangeCards();
    }

    private void ArrangeCards()
    {
        switch (groupingType)
        {
            case GroupingType.stack:
                for (int i = 0; i < cardsList.Count; i++)
                {
                    cardsList[i].transform.position = placementTransform.position + (Vector3.up * CardManager.stackCardSpacing * i);
                    cardsList[i].SetCanvasOrderInLayer(orderInLayer + i); 
                }
                break;
            case GroupingType.hand:
                float availableArea = 2;
                float evenQuantityOffset = cardsList.Count % 2f > 0 ? 0 : 0.5f;
                float maxOffset = .31415926f * 1.25f;
                float naturalOffset = availableArea / (cardsList.Count / 2);
                float clampedOffset = maxOffset < naturalOffset ? maxOffset : naturalOffset;

                for (int i = 0; i < cardsList.Count; i++)
                {
                    cardsList[i].SetCanvasOrderInLayer(orderInLayer + cardsList.Count - i );
                    cardsList[i].transform.localPosition = Vector3.left * clampedOffset * (i - (cardsList.Count / 2) + evenQuantityOffset);
                }
                break;
            default:
                break;
        }
    }


    public enum GroupingType
    {
        board,
        hand,
        stack,
    }
}
