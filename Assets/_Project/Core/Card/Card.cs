using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpectrobesTCG
{
    public class Card : MonoBehaviour
    {
        public CardManager.CardType type;

        private readonly string cardFrontString = "Scaler/CardBackSprite/CardFront";
        private CardManager cardManager;
        private GameManager gameManager;
        private GameManager.PlayerIds controllerId;
        private GameManager.PlayerIds ownerId;
        private List<GameManager.PlayerIds> playerVisibilityIds = new List<GameManager.PlayerIds>();
        private string title;

        public void Initialize(GameManager.PlayerIds playerId)
        {
            ownerId = playerId;
            controllerId = playerId;

            gameManager = GameManager.instance;
            cardManager = CardManager.instance;

            ApplyCardVisibility();
        }

        public List<GameManager.PlayerIds> PlayerVisibilityIds { get { return playerVisibilityIds; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        virtual public void OnAddedToDeck() { if (Application.isEditor) Debug.Log("OnAddedToDeck: Using default Card logic"); }
        virtual public void OnPlayed() { if (Application.isEditor) Debug.Log("OnPlayCard: Using default Card logic"); }
        virtual public void OnDestroyed() { if (Application.isEditor) Debug.Log("OnDestroyed: Using default Card logic"); }
        virtual public void OnExiled() { if (Application.isEditor) Debug.Log("OnExiled: Using default Card logic"); }
        virtual public void OnBoardEnter() { if (Application.isEditor) Debug.Log("OnBoardEnter: Using default Card logic"); }
        virtual public void OnBoardExit() { if (Application.isEditor) Debug.Log("OnBoardExit: Using default Card logic"); }
        virtual public void OnDiscardFromHand() { if (Application.isEditor) Debug.Log("OnDiscardFromHand: Using default Card logic"); }
        virtual public void OnEnterGraveyard() { if (Application.isEditor) Debug.Log("OnEnterGraveyard: Using default Card logic"); }
        virtual public void OnTargeted() { if (Application.isEditor) Debug.Log("OnTargeted: Using default Card logic"); }
        public void AddPlayerVisibilityId(GameManager.PlayerIds playerId)
        {
            playerVisibilityIds.Add(playerId);
            ApplyCardVisibility();
        }
        public void ApplyCardVisibility()
        {
            if (playerVisibilityIds.Contains(gameManager.clientId)) ShowCardFront();
            else ShowCardBack();

        }
        public void PurgePlayerVisibilityIds()
        {
            playerVisibilityIds.Clear();
            ApplyCardVisibility();
        }
        public void ShowCardFront() { transform.Find(cardFrontString).gameObject.SetActive(true); }
        public void ShowCardBack() { transform.Find(cardFrontString)?.gameObject.SetActive(false); }
    }
}
