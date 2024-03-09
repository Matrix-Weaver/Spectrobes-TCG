using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpectrobesTCG
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public readonly float minWaitTime = 0.1047197551f;
        public readonly PlayerIds clientId = PlayerIds.player1;

        public List<PlayerManager> players = new List<PlayerManager>();
        public Transform dynamicTransform;
        public Transform gameplayTransform;
        public Transform[] boardTransforms;
        public Transform[] deckTransforms;
        public Transform[] discardTransforms;
        public Transform[] handTransforms;

        [SerializeField]
        private PlayerManager currentPlayer;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            instance = this;
            for (int i = 0; i < 2; i++)
            {
                Dictionary<string, Transform> cardListTransforms = new Dictionary<string, Transform>();
                cardListTransforms.Add("deck", deckTransforms[i]);
                cardListTransforms.Add("hand", handTransforms[i]);
                // cardListTransforms.Add("board", boardTransforms[i]);
                cardListTransforms.Add("discard", discardTransforms[i]);
                switch (i)
                {
                    case 0:
                        CreatePlayer(PlayerIds.player1, cardListTransforms);
                        break;
                    case 1:
                        CreatePlayer(PlayerIds.player2, cardListTransforms);
                        break;
                    default:
                        break;
                }
            }
            yield return new WaitForSeconds(1);
            StartCoroutine(StartGame());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CreatePlayer(PlayerIds playerId, Dictionary<string, Transform> cardListTransforms)
        {
            PlayerManager newPlayer = new PlayerManager(playerId, cardListTransforms);
            players.Add(newPlayer);
        }

        //* returns a random playerId
        public PlayerManager GetRandomPlayerManager()
        {
            int r = Random.Range(0, players.Count);
            return players[r];
        }

        IEnumerator StartGame()
        {
            for (int i = 0; i < players.Count; i++)
            {
                StartCoroutine(players[i].DrawCards(7));
            }
            yield return new WaitForSeconds(1);
            currentPlayer = GetRandomPlayerManager();
            currentPlayer.StartTurn();
        }


        public enum PlayerIds
        {
            player1,
            player2,
        }

        public enum TurnPhases
        {
            start,
        }

    }
}