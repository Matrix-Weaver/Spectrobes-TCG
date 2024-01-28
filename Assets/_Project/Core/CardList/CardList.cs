using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Threading;
using SpectrobesTCG;
using UnityEngine;

public class CardList
{
    private readonly List<Card> cards = new List<Card>();
    private GameManager.PlayerIds controllerId;
    private GroupingType groupingType;
    private GameManager.PlayerIds ownerId;
    private Transform placementTransform;

    public CardList(GameManager.PlayerIds playerId)
    {
        ownerId = playerId;
        controllerId = playerId;
    }

    public CardList(GameManager.PlayerIds playerId, GroupingType groupingType, Transform placementTransform)
    {
        ownerId = playerId;
        controllerId = playerId;

        this.groupingType = groupingType;
        this.placementTransform = placementTransform;
    }

    public List<Card> Cards { get { return cards; } }
    public Transform ParentTransform { get { return placementTransform; } }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignTransformPosition(Transform parentTransform)
    {
        this.placementTransform = parentTransform;
    }

    public void AddCard(Card card, Boolean arrangeCards = false, int index = -1)
    {
        card.transform.SetParent(placementTransform);
        if (index >= 0 && index < cards.Count)
            cards.Insert(index, card);
        else
            cards.Add(card);
        if (arrangeCards)
            ArrangeCards();
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    public void Shuffle(bool shouldPurgeVisibility = false)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = cards.Count;
        while (n > 0)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (box[0] >= n * (Byte.MaxValue / n));
            int k = (box[0] % n);
            n--;
            Card card = cards[k];
            cards[k] = cards[n];
            cards[n] = card;
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
                for (int i = 0; i < cards.Count; i++)
                {
                    cards[i].transform.position = placementTransform.position + (Vector3.up * CardManager.stackCardSpacing * i);
                }
                break;
            case GroupingType.horizontal:
                float availableArea = 2;
                float evenQuantityOffset = cards.Count % 2f > 0 ? 0 : 0.5f;
                float maxOffset = .31415926f * 1.25f;
                float naturalOffset = availableArea / (cards.Count / 2);
                float clampedOffset = maxOffset < naturalOffset ? maxOffset : naturalOffset;

                for (int i = 0; i < cards.Count; i++)
                {
                    cards[i].transform.localPosition = Vector3.left * clampedOffset * (i - (cards.Count / 2) + evenQuantityOffset);
                }
                break;
            default:
                break;
        }
    }


    public enum GroupingType
    {
        horizontal,
        stack,
    }
}
