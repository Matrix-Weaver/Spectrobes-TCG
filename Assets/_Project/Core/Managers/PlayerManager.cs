using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpectrobesTCG
{
    public class PlayerManager
    {

        private CardList boardList;
        private CardList deckList;
        private CardList discardList;
        private CardList exiledList;
        private CardList handList;
        private CardList phasedOutList;
        private CardManager cardManager;
        private GameManager gameManager;
        private GameManager.PlayerIds id;

        public PlayerManager(GameManager.PlayerIds playerId, Dictionary<string, Transform> cardListTransforms)
        {
            this.id = playerId;

            gameManager = GameManager.instance;
            cardManager = CardManager.instance;

            // create all card lists
            deckList = new CardList(id, CardList.GroupingType.stack, cardListTransforms["deck"]);
            handList = new CardList(id, CardList.GroupingType.horizontal, cardListTransforms["hand"]);
            boardList = new CardList(id, CardList.GroupingType.horizontal, cardListTransforms["deck"]);
            discardList = new CardList(id, CardList.GroupingType.stack, cardListTransforms["discard"]);
            exiledList = new CardList(id);
            phasedOutList = new CardList(id);

            // add cards to deckList
            BuildDeck(cardListTransforms["deck"]);
        }

        public IEnumerator DrawCards(int amount)
        {
            float dividedWaitTime = 0.31415926f / amount;
            float waitTime = dividedWaitTime < gameManager.minWaitTime ? gameManager.minWaitTime : dividedWaitTime;
            for (int i = 0; i < amount; i++)
            {
                Card card = deckList.Cards[deckList.Cards.Count - 1];
                deckList.RemoveCard(card);
                handList.AddCard(card, true);
                card.AddPlayerVisibilityId(id);
                yield return new WaitForSeconds(waitTime);
            }
        }

        public void MillCards(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Card card = deckList.Cards[deckList.Cards.Count - 1];
                deckList.RemoveCard(card);
                discardList.AddCard(card);
            }
        }

        public void DiscardCards(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Card card = handList.Cards[handList.Cards.Count - 1];
                handList.RemoveCard(card);
                discardList.AddCard(card);
            }
        }

        public void StartTurn()
        {
            // Turn setup goes here
        }

        public void EndTurn()
        {
            // Turn cleanup goes here
        }

        private void BuildDeck(Transform deckTransform)
        {
            deckList.AssignTransformPosition(deckTransform);
            for (int i = 0; i < 60; i++)
            {
                Card card = GameManager.Instantiate(cardManager.spectrobeCardPrefab, deckTransform);
                card.Initialize(id);
                deckList.AddCard(card);
            }
            deckList.Shuffle(true);
        }
    }
}