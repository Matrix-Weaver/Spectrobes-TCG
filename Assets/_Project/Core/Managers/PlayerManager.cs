using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpectrobesTCG
{
    public class PlayerManager
    {

        private readonly CardZone boardZone;
        private readonly CardZone deckZone;
        private readonly CardZone discardZone;
        private readonly CardZone exileZone;
        private readonly CardZone handZone;
        private readonly CardZone phasedOutZone;
        private readonly CardManager cardManagerInstance;
        private readonly GameManager gameManagerInstance;
        private readonly GameManager.PlayerIds id;

        public PlayerManager(GameManager.PlayerIds playerId, Dictionary<string, Transform> cardListTransforms)
        {
            this.id = playerId;

            gameManagerInstance = GameManager.instance;
            cardManagerInstance = CardManager.instance;

            deckZone = new CardZone(id, CardZone.GroupingType.stack, cardListTransforms["deck"]);
            handZone = new CardZone(id, CardZone.GroupingType.horizontal, cardListTransforms["hand"]);
            discardZone = new CardZone(id, CardZone.GroupingType.stack, cardListTransforms["discard"]);
            exileZone = new CardZone(id);
            phasedOutZone = new CardZone(id);
            /*
                TODO boardZone needs to be separated into 2 different zones (bench and team)
                TODO Will require work to set up those zones in the scene
            */
            boardZone = new CardZone(id, CardZone.GroupingType.horizontal, cardListTransforms["deck"]);

            BuildDeck(cardListTransforms["deck"]);
        }

        public IEnumerator DrawCards(int amount)
        {
            float dividedWaitTime = 0.31415926f / amount;
            float waitTime = dividedWaitTime < gameManagerInstance.minWaitTime ? gameManagerInstance.minWaitTime : dividedWaitTime;
            for (int i = 0; i < amount; i++)
            {
                Card card = deckZone.CardsList[deckZone.CardsList.Count - 1];
                deckZone.RemoveCard(card);
                handZone.AddCard(card, true);
                card.AddPlayerVisibilityId(id);
                yield return new WaitForSeconds(waitTime);
            }
        }

        public void MillCards(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Card card = deckZone.CardsList[deckZone.CardsList.Count - 1];
                deckZone.RemoveCard(card);
                discardZone.AddCard(card);
            }
        }

        public void DiscardCards(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Card card = handZone.CardsList[handZone.CardsList.Count - 1];
                handZone.RemoveCard(card);
                discardZone.AddCard(card);
            }
        }

        public void StartTurn()
        {
            gameManagerInstance.StartCoroutine((DrawCards(1)));
        }

        public void EndTurn()
        {
            // Turn cleanup goes here
        }

        private void BuildDeck(Transform deckTransform)
        {
            for (int i = 0; i < 60; i++)
            {
                Card card = GameManager.Instantiate(cardManagerInstance.spectrobeCardPrefab, deckTransform);
                card.Initialize(id);
                deckZone.AddCard(card);
            }
            deckZone.Shuffle(true);
        }
    }
}